﻿/* 
 * Copyright (c) 2014, Furore (info@furore.com) and contributors
 * See the file CONTRIBUTORS for details.
 * 
 * This file is licensed under the BSD 3-Clause license
 * available at https://raw.githubusercontent.com/ewoutkramer/fhir-net-api/master/LICENSE
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hl7.Fhir.Introspection.Source;
using Hl7.Fhir.Model;
using Hl7.Fhir.Support;

namespace Hl7.Fhir.Introspection
{
    public class StructureLoader
    {
        public StructureLoader(IArtifactSource source)
        {
            ArtifactSource = source;
        }

        public IArtifactSource ArtifactSource { get; private set; }


        /// <summary>
        /// Locate a structures within a profile given by an uri
        /// </summary>
        /// <param name="structureUri">An Uri pointing to a profile or a structure within a profile</param>
        /// <param name="type">Resource or Datatype that the structure is constraining</param>
        /// <returns>The structure as indicated by the uri or null if it was not found</returns>
        /// <remarks>This function accepts an uri that has only the profile's address, or a uri that has both the 
        /// address and an achor indicating the name of the structure to locate (e.g. http://someplace.org/fhir/Profiles/myprofile#somestructure).
        /// </remarks>
        public Profile.ProfileStructureComponent Locate(Uri structureUri, Code type = null)
        {
            if (structureUri == null) throw Error.ArgumentNull("structureUri");
            if (!structureUri.IsAbsoluteUri) throw Error.Argument("Reference to structure must be an absolute url");

            // The structure Uri might be of the form <url-to-profile>#<structure name>
            // First split off the <url-to-profile> and load the profile
            var uriWithoutAnchor = new UriBuilder(structureUri);
            uriWithoutAnchor.Fragment = null;

            var profile = loadProfile(uriWithoutAnchor.Uri);

            // If the profile was not found, return without doing work
            if (profile == null || profile.Structure == null || profile.Structure.Count == 0) return null;

            // Determine the anchor, which we use to locate the structure by comparing it to Structure.name
            var anchor = structureUri.Fragment.TrimStart('#');

            return locate(profile, anchor, type);
        }


        private static Profile.ProfileStructureComponent locate(Profile profile, string anchor, Code type)
        {
            if(String.IsNullOrEmpty(anchor)) anchor = null;

            IEnumerable<Profile.ProfileStructureComponent> results = null;

            if (anchor == null && type == null)
            {
                // We have NO structure name and NO type hint. This is only unambiguous if there's just 1 structure in the profile
                results = profile.Structure;
            }
            else if(anchor != null && type == null)
            {
                // We have a structure name but NO specific type. This is normally unambiguous, since the name should be unique
                results = profile.Structure.Where(str => str.Name == anchor);
            }
            else if (anchor == null && type != null)
            {
                // We don't know the structure name but have it's type. This is unambiguous if there's just one structure of the given type
                results = profile.Structure.Where(str => str.Type == type.Value);
            }
            else
            {
                // We have both the name and the type, this should also normally be unique
                results = profile.Structure.Where(str => str.Name == anchor && str.Type == type.Value);
            }
            
            if (results.Count() <= 1)
                return results.SingleOrDefault();
            else
                throw Error.InvalidOperation("Cannot unambiguously determine structure to locate based on the given combination of url, anchor and structure type");
        }

        /// <summary>
        /// Locate base structures for a given FHIR core type
        /// </summary>
        /// <param name="type">The Resource or Datatype to locate</param>
        /// <returns></returns>
        public Profile.ProfileStructureComponent LocateBaseStructure(Code type)
        {
            return Locate(BuildBaseStructureUri(type),type);
        }


        /// <summary>
        /// All base structures (resources + datatypes) that come with the spec have a specific pre-defined
        /// (but currently symbolic) url where they can be found. This function constructs this Url, given the
        /// core Resource or Datatype code.
        /// </summary>
        /// <param name="type">Resource or Datatype to build the Uri for</param>
        /// <returns></returns>
        public static Uri BuildBaseStructureUri(Code type)
        {
            //string fullReference = CoreZipArtifactSource.CORE_SPEC_PROFILE_URI_PREFIX + type.Value.ToLower();
            string fullReference = CoreZipArtifactSource.CORE_SPEC_PROFILE_URI_PREFIX + type.Value;
            return new Uri(fullReference);
        }

        private Profile loadProfile(Uri profileUri)
        {
            var profile = ArtifactSource.ReadResourceArtifact(profileUri) as Profile;

            if (profile == null) return null;

            // Do preprocessing
            //if(profile.GetProfileLocation() == null)
            //    profile.SetProfileLocation(profileUri);

            return profile;
        }
    }
}
