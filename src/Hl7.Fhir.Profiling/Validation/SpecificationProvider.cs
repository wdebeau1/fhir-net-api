﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Introspection;
using Hl7.Fhir.Introspection.Source;

namespace Hl7.Fhir.Profiling
{
    using Model = Hl7.Fhir.Model;

    public class SpecificationProvider
    {
        IArtifactSource source;
        SpecificationHarvester harvester;
        StructureLoader loader;
        

        public SpecificationProvider(IArtifactSource source)
        {
            this.source = source;
            this.loader = new StructureLoader(source);
            this.harvester = new SpecificationHarvester();
        }

        public static SpecificationProvider CreateDefault()
        {
            IArtifactSource source = ArtifactResolver.CreateCachedDefault();
            return new SpecificationProvider(source);
        }

        public static SpecificationProvider CreateOffline(params IArtifactSource[] sources)
        {
            ArtifactResolver resolver = new ArtifactResolver();
            foreach (IArtifactSource s in sources) resolver.AddSource(s);
            resolver.AddSource(new CoreZipArtifactSource());
            resolver.AddSource(new FileArtifactSource());
            
            IArtifactSource cache = new CachedArtifactSource(resolver);
            return new SpecificationProvider(cache);
        }

        
        private T Resolve<T>(Uri uri) where T : Model.Resource
        {
            loader.Locate(uri);
            Model.Resource resource = source.ReadResourceArtifact(uri);
            return (T)resource;
        }
        

        public Structure GetStructure(Uri uri)
        {
            Model.Profile.ProfileStructureComponent component = loader.Locate(uri);
            if (component != null)
            {
                Structure structure = harvester.HarvestStructure(component, uri);
                return structure;
            }
            return null;
        }
         


        public static IEnumerable<T> Singleton<T>(T item)
        {
            if (item != null)
                yield return item;
            else
                yield break;
        }

        public IEnumerable<Structure> GetStructures(Uri uri)
        {
            Structure structure = GetStructure(uri);
            return Singleton(structure);
        }

        /*
        public IEnumerable<Structure> GetStructures(Uri uri)
        {
            Model.Profile profile = Resolve<Model.Profile>(uri);
            if (profile != null)
            {
                IEnumerable<Structure> structures = harvester.HarvestStructures(profile);
                UriHelper.SetStructureIdentification(structures, uri);
                return structures;
            }
            else
            {
                return Enumerable.Empty<Structure>();
            }
        }
        */

        public IEnumerable<Structure> GetStructures(string uri)
        {
            return GetStructures(new Uri(uri));
        }

        public IEnumerable<Structure> GetStructures(TypeRef typeref)
        {
            Uri uri = typeref.Uri;
            return GetStructures(uri);
        }

        
        public ValueSet GetValueSet(Uri uri)
        {
            Model.ValueSet source = Resolve<Model.ValueSet>(uri);
            if (source != null)
            {
                ValueSet target = harvester.HarvestValueSet(source);
                return target;
            }
            return null;
        }

        public IEnumerable<ValueSet> GetValueSets(IEnumerable<Uri> uris)
        {
            foreach (Uri uri in uris)
            {
                ValueSet valueset = GetValueSet(uri);
                if (valueset != null) yield return valueset;

            }
        }
    }
}
