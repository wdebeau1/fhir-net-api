﻿/* 
 * Copyright (c) 2014, Furore (info@furore.com) and contributors
 * See the file CONTRIBUTORS for details.
 * 
 * This file is licensed under the BSD 3-Clause license
 * available at https://raw.githubusercontent.com/ewoutkramer/fhir-net-api/master/LICENSE
 */

using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hl7.Fhir.Model;
using Hl7.Fhir.Support;
using System.Diagnostics;
using System.IO;
using Hl7.Fhir.Introspection;
using Hl7.Fhir.Introspection.Source;
using Hl7.Fhir.Serialization;
using System.Xml.Linq;
using System.Xml.Schema;

namespace Hl7.Fhir.Test.Inspection
{
#if !PORTABLE45
    [TestClass]
    public class SchemaCollectionTest
    {
        [TestMethod]
        public void TestSchemaCompilation()
        {
            var schemas = SchemaCollection.ValidationSchemaSet;
            Assert.IsTrue(schemas.Count > 0);

            var patDoc = XDocument.Parse("<Patient xmlns='http://hl7.org/fhir' />");
            patDoc.Validate(SchemaCollection.ValidationSchemaSet, null);

            try
            {
                patDoc = XDocument.Parse("<Patient xmlns='http://hl7.org/fhir'><garbage/></Patient>");
                patDoc.Validate(SchemaCollection.ValidationSchemaSet, null);
                Assert.Fail();
            }
            catch
            {
                // perfect.
            }

            var hasError = false;
            patDoc = XDocument.Parse("<Patient xmlns='http://hl7.org/fhir'><garbage/></Patient>");
            patDoc.Validate(SchemaCollection.ValidationSchemaSet, (source,args) => hasError = true);
            Assert.IsTrue(hasError);
        }

        [TestMethod]
        public void TestSchemaCollectionValidation()
        {
            // This kind of test is also done in Introspection/SchemaCollectionTest....

            var s = this.GetType().Assembly.GetManifestResourceStream("Hl7.Fhir.Test.patient-example.xml");
            var doc = XDocument.Load(s);

            bool hasError = false;

            doc.Validate(SchemaCollection.ValidationSchemaSet, (source, args) => hasError = true);

            Assert.IsFalse(hasError);
        }

    }
#endif
}