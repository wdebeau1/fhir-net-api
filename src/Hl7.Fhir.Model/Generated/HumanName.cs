﻿using System;
using System.Collections.Generic;
using Hl7.Fhir.Introspection;
using Hl7.Fhir.Validation;
using System.Linq;
using System.Runtime.Serialization;

/*
  Copyright (c) 2011-2013, HL7, Inc.
  All rights reserved.
  
  Redistribution and use in source and binary forms, with or without modification, 
  are permitted provided that the following conditions are met:
  
   * Redistributions of source code must retain the above copyright notice, this 
     list of conditions and the following disclaimer.
   * Redistributions in binary form must reproduce the above copyright notice, 
     this list of conditions and the following disclaimer in the documentation 
     and/or other materials provided with the distribution.
   * Neither the name of HL7 nor the names of its contributors may be used to 
     endorse or promote products derived from this software without specific 
     prior written permission.
  
  THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND 
  ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED 
  WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. 
  IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, 
  INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT 
  NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR 
  PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, 
  WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) 
  ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE 
  POSSIBILITY OF SUCH DAMAGE.
  

*/

//
// Generated on Tue, Jul 15, 2014 15:45+0200 for FHIR v0.0.81
//
namespace Hl7.Fhir.Model
{
    /// <summary>
    /// Name of a human - parts and usage
    /// </summary>
    [FhirType("HumanName")]
    [DataContract]
    public partial class HumanName : Hl7.Fhir.Model.Element, System.ComponentModel.INotifyPropertyChanged
    {
        /// <summary>
        /// The use of a human name
        /// </summary>
        [FhirEnumeration("NameUse")]
        public enum NameUse
        {
            /// <summary>
            /// Known as/conventional/the one you normally use.
            /// </summary>
            [EnumLiteral("usual")]
            Usual,
            /// <summary>
            /// The formal name as registered in an official (government) registry, but which name might not be commonly used. May be called "legal name".
            /// </summary>
            [EnumLiteral("official")]
            Official,
            /// <summary>
            /// A temporary name. Name.period can provide more detailed information. This may also be used for temporary names assigned at birth or in emergency situations.
            /// </summary>
            [EnumLiteral("temp")]
            Temp,
            /// <summary>
            /// A name that is used to address the person in an informal manner, but is not part of their formal or usual name.
            /// </summary>
            [EnumLiteral("nickname")]
            Nickname,
            /// <summary>
            /// Anonymous assigned name, alias, or pseudonym (used to protect a person's identity for privacy reasons).
            /// </summary>
            [EnumLiteral("anonymous")]
            Anonymous,
            /// <summary>
            /// This name is no longer in use (or was never correct, but retained for records).
            /// </summary>
            [EnumLiteral("old")]
            Old,
            /// <summary>
            /// A name used prior to marriage. Marriage naming customs vary greatly around the world. This name use is for use by applications that collect and store "maiden" names. Though the concept of maiden name is often gender specific, the use of this term is not gender specific. The use of this term does not imply any particular history for a person's name, nor should the maiden name be determined algorithmically.
            /// </summary>
            [EnumLiteral("maiden")]
            Maiden,
        }
        
        /// <summary>
        /// usual | official | temp | nickname | anonymous | old | maiden
        /// </summary>
        [FhirElement("use", InSummary=true, Order=40)]
        [DataMember]
        public Code<Hl7.Fhir.Model.HumanName.NameUse> UseElement
        {
            get { return _UseElement; }
            set { _UseElement = value; OnPropertyChanged("UseElement"); }
        }
        private Code<Hl7.Fhir.Model.HumanName.NameUse> _UseElement;
        
        /// <summary>
        /// usual | official | temp | nickname | anonymous | old | maiden
        /// </summary>
        /// <remarks>This uses the native .NET datatype, rather than the FHIR equivalent</remarks>
        [NotMapped]
        [IgnoreDataMemberAttribute]
        public Hl7.Fhir.Model.HumanName.NameUse? Use
        {
            get { return UseElement != null ? UseElement.Value : null; }
            set
            {
                if(value == null)
                  UseElement = null; 
                else
                  UseElement = new Code<Hl7.Fhir.Model.HumanName.NameUse>(value);
                OnPropertyChanged("Use");
            }
        }
        
        /// <summary>
        /// Text representation of the full name
        /// </summary>
        [FhirElement("text", InSummary=true, Order=50)]
        [DataMember]
        public Hl7.Fhir.Model.FhirString TextElement
        {
            get { return _TextElement; }
            set { _TextElement = value; OnPropertyChanged("TextElement"); }
        }
        private Hl7.Fhir.Model.FhirString _TextElement;
        
        /// <summary>
        /// Text representation of the full name
        /// </summary>
        /// <remarks>This uses the native .NET datatype, rather than the FHIR equivalent</remarks>
        [NotMapped]
        [IgnoreDataMemberAttribute]
        public string Text
        {
            get { return TextElement != null ? TextElement.Value : null; }
            set
            {
                if(value == null)
                  TextElement = null; 
                else
                  TextElement = new Hl7.Fhir.Model.FhirString(value);
                OnPropertyChanged("Text");
            }
        }
        
        /// <summary>
        /// Family name (often called 'Surname')
        /// </summary>
        [FhirElement("family", InSummary=true, Order=60)]
        [Cardinality(Min=0,Max=-1)]
        [DataMember]
        public List<Hl7.Fhir.Model.FhirString> FamilyElement
        {
            get { return _FamilyElement; }
            set { _FamilyElement = value; OnPropertyChanged("FamilyElement"); }
        }
        private List<Hl7.Fhir.Model.FhirString> _FamilyElement;
        
        /// <summary>
        /// Family name (often called 'Surname')
        /// </summary>
        /// <remarks>This uses the native .NET datatype, rather than the FHIR equivalent</remarks>
        [NotMapped]
        [IgnoreDataMemberAttribute]
        public IEnumerable<string> Family
        {
            get { return FamilyElement != null ? FamilyElement.Select(elem => elem.Value) : null; }
            set
            {
                if(value == null)
                  FamilyElement = null; 
                else
                  FamilyElement = new List<Hl7.Fhir.Model.FhirString>(value.Select(elem=>new Hl7.Fhir.Model.FhirString(elem)));
                OnPropertyChanged("Family");
            }
        }
        
        /// <summary>
        /// Given names (not always 'first'). Includes middle names
        /// </summary>
        [FhirElement("given", InSummary=true, Order=70)]
        [Cardinality(Min=0,Max=-1)]
        [DataMember]
        public List<Hl7.Fhir.Model.FhirString> GivenElement
        {
            get { return _GivenElement; }
            set { _GivenElement = value; OnPropertyChanged("GivenElement"); }
        }
        private List<Hl7.Fhir.Model.FhirString> _GivenElement;
        
        /// <summary>
        /// Given names (not always 'first'). Includes middle names
        /// </summary>
        /// <remarks>This uses the native .NET datatype, rather than the FHIR equivalent</remarks>
        [NotMapped]
        [IgnoreDataMemberAttribute]
        public IEnumerable<string> Given
        {
            get { return GivenElement != null ? GivenElement.Select(elem => elem.Value) : null; }
            set
            {
                if(value == null)
                  GivenElement = null; 
                else
                  GivenElement = new List<Hl7.Fhir.Model.FhirString>(value.Select(elem=>new Hl7.Fhir.Model.FhirString(elem)));
                OnPropertyChanged("Given");
            }
        }
        
        /// <summary>
        /// Parts that come before the name
        /// </summary>
        [FhirElement("prefix", InSummary=true, Order=80)]
        [Cardinality(Min=0,Max=-1)]
        [DataMember]
        public List<Hl7.Fhir.Model.FhirString> PrefixElement
        {
            get { return _PrefixElement; }
            set { _PrefixElement = value; OnPropertyChanged("PrefixElement"); }
        }
        private List<Hl7.Fhir.Model.FhirString> _PrefixElement;
        
        /// <summary>
        /// Parts that come before the name
        /// </summary>
        /// <remarks>This uses the native .NET datatype, rather than the FHIR equivalent</remarks>
        [NotMapped]
        [IgnoreDataMemberAttribute]
        public IEnumerable<string> Prefix
        {
            get { return PrefixElement != null ? PrefixElement.Select(elem => elem.Value) : null; }
            set
            {
                if(value == null)
                  PrefixElement = null; 
                else
                  PrefixElement = new List<Hl7.Fhir.Model.FhirString>(value.Select(elem=>new Hl7.Fhir.Model.FhirString(elem)));
                OnPropertyChanged("Prefix");
            }
        }
        
        /// <summary>
        /// Parts that come after the name
        /// </summary>
        [FhirElement("suffix", InSummary=true, Order=90)]
        [Cardinality(Min=0,Max=-1)]
        [DataMember]
        public List<Hl7.Fhir.Model.FhirString> SuffixElement
        {
            get { return _SuffixElement; }
            set { _SuffixElement = value; OnPropertyChanged("SuffixElement"); }
        }
        private List<Hl7.Fhir.Model.FhirString> _SuffixElement;
        
        /// <summary>
        /// Parts that come after the name
        /// </summary>
        /// <remarks>This uses the native .NET datatype, rather than the FHIR equivalent</remarks>
        [NotMapped]
        [IgnoreDataMemberAttribute]
        public IEnumerable<string> Suffix
        {
            get { return SuffixElement != null ? SuffixElement.Select(elem => elem.Value) : null; }
            set
            {
                if(value == null)
                  SuffixElement = null; 
                else
                  SuffixElement = new List<Hl7.Fhir.Model.FhirString>(value.Select(elem=>new Hl7.Fhir.Model.FhirString(elem)));
                OnPropertyChanged("Suffix");
            }
        }
        
        /// <summary>
        /// Time period when name was/is in use
        /// </summary>
        [FhirElement("period", InSummary=true, Order=100)]
        [DataMember]
        public Hl7.Fhir.Model.Period Period
        {
            get { return _Period; }
            set { _Period = value; OnPropertyChanged("Period"); }
        }
        private Hl7.Fhir.Model.Period _Period;
        
        public override IDeepCopyable CopyTo(IDeepCopyable other)
        {
            var dest = other as HumanName;
            
            if (dest != null)
            {
                base.CopyTo(dest);
                if(UseElement != null) dest.UseElement = (Code<Hl7.Fhir.Model.HumanName.NameUse>)UseElement.DeepCopy();
                if(TextElement != null) dest.TextElement = (Hl7.Fhir.Model.FhirString)TextElement.DeepCopy();
                if(FamilyElement != null) dest.FamilyElement = new List<Hl7.Fhir.Model.FhirString>(FamilyElement.DeepCopy());
                if(GivenElement != null) dest.GivenElement = new List<Hl7.Fhir.Model.FhirString>(GivenElement.DeepCopy());
                if(PrefixElement != null) dest.PrefixElement = new List<Hl7.Fhir.Model.FhirString>(PrefixElement.DeepCopy());
                if(SuffixElement != null) dest.SuffixElement = new List<Hl7.Fhir.Model.FhirString>(SuffixElement.DeepCopy());
                if(Period != null) dest.Period = (Hl7.Fhir.Model.Period)Period.DeepCopy();
                return dest;
            }
            else
            	throw new ArgumentException("Can only copy to an object of the same type", "other");
        }
        
        public override IDeepCopyable DeepCopy()
        {
            return CopyTo(new HumanName());
        }
        
    }
    
}
