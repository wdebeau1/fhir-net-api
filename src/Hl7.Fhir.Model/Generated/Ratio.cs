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
    /// A ratio of two Quantity values - a numerator and a denominator
    /// </summary>
    [FhirType("Ratio")]
    [DataContract]
    public partial class Ratio : Hl7.Fhir.Model.Element, System.ComponentModel.INotifyPropertyChanged
    {
        /// <summary>
        /// Numerator value
        /// </summary>
        [FhirElement("numerator", InSummary=true, Order=40)]
        [DataMember]
        public Hl7.Fhir.Model.Quantity Numerator
        {
            get { return _Numerator; }
            set { _Numerator = value; OnPropertyChanged("Numerator"); }
        }
        private Hl7.Fhir.Model.Quantity _Numerator;
        
        /// <summary>
        /// Denominator value
        /// </summary>
        [FhirElement("denominator", InSummary=true, Order=50)]
        [DataMember]
        public Hl7.Fhir.Model.Quantity Denominator
        {
            get { return _Denominator; }
            set { _Denominator = value; OnPropertyChanged("Denominator"); }
        }
        private Hl7.Fhir.Model.Quantity _Denominator;
        
        public override IDeepCopyable CopyTo(IDeepCopyable other)
        {
            var dest = other as Ratio;
            
            if (dest != null)
            {
                base.CopyTo(dest);
                if(Numerator != null) dest.Numerator = (Hl7.Fhir.Model.Quantity)Numerator.DeepCopy();
                if(Denominator != null) dest.Denominator = (Hl7.Fhir.Model.Quantity)Denominator.DeepCopy();
                return dest;
            }
            else
            	throw new ArgumentException("Can only copy to an object of the same type", "other");
        }
        
        public override IDeepCopyable DeepCopy()
        {
            return CopyTo(new Ratio());
        }
        
    }
    
}
