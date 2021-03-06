﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fhir.IO;

namespace Fhir.Profiling.Tests
{
    [TestClass]
    public class TestSimpleValidation
    {
        static Specification patientSpec;
        
        [ClassInitialize]
        public static void Init(TestContext context)
        {
            patientSpec = Factory.GetPatientSpec();
        }

        [TestMethod]
        public void InvalidElement()
        {
            var resource = FhirFile.LoadResource("TestData\\Patient.InvalidElement.xml");
            Report report = patientSpec.Validate(resource);

            Assert.IsFalse(report.IsValid);
            Assert.AreEqual(1, report.ErrorCount);
            Assert.IsTrue(report.Contains(Group.Element, Status.Unknown));
        }
    }
}
