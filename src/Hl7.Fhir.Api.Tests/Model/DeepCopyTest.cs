﻿/* 
 * Copyright (c) 2014, Furore (info@furore.com) and contributors
 * See the file CONTRIBUTORS for details.
 * 
 * This file is licensed under the BSD 3-Clause license
 * available at https://raw.githubusercontent.com/ewoutkramer/fhir-net-api/master/LICENSE
 */

using Hl7.Fhir.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Hl7.Fhir.Serialization;
using System.Xml;

namespace Hl7.Fhir.Test
{
    [TestClass]
#if PORTABLE45
	public class PortableDeepCopyTest
#else
    public class DeepCopyTest
#endif
    {
        [TestMethod]
        public void CheckCopyAllFields()
        {
            Stream xmlExample = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("Hl7.Fhir.Test.TestPatient.xml");
            string xml = new StreamReader(xmlExample).ReadToEnd();

            var p = (Patient)FhirParser.ParseResourceFromXml(xml);
            var p2 = (Patient)p.DeepCopy();
            var xml2 = FhirSerializer.SerializeResourceToXml(p2);
            XmlAssert.AreSame(xml, xml2);
        }
    }
}
