using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ValidParens.Tests
{
    [TestClass]
    public class ValidatorTests
    {
        private ParenValidator _validator;

        [TestInitialize]
        public void TestInit()
        {
            _validator = new ParenValidator();
        }

        [TestMethod]
        public void EmptyString_IsValid()
        {
            var toValidate = string.Empty;

            var toCheck = _validator.IsValid(toValidate);

            Assert.IsTrue(toCheck);
        }

        [TestMethod]
        public void MatchingParens_AreValid()
        {
            var toValidate = "()";

            var toCheck = _validator.IsValid(toValidate);

            Assert.IsTrue(toCheck);
        }

        [TestMethod]
        public void NonMatchingParents_AreNotValid()
        {
            var toValidate = "(";

            var toCheck = _validator.IsValid(toValidate);

            Assert.IsFalse(toCheck);
        }

        [TestMethod]
        public void NestedParens_AreValid()
        {
            var toValidate = "(())";

            var toCheck = _validator.IsValid(toValidate);

            Assert.IsTrue(toCheck);
        }

        [TestMethod]
        public void NestedParensWithBraces_AreValid()
        {
            var toValidate = "({})";

            var toCheck = _validator.IsValid(toValidate);

            Assert.IsTrue(toCheck);
        }

        [TestMethod]
        public void NestedParensWithUnmatchedBraces_AreValid()
        {
            var toValidate = "({)";

            var toCheck = _validator.IsValid(toValidate);

            Assert.IsFalse(toCheck);
        }

        [TestMethod]
        public void GroupsThatEndAfterTheirParents_AreInValid()
        {
            var toValidate = "({)}";

            var toCheck = _validator.IsValid(toValidate);

            Assert.IsFalse(toCheck);
        }
    }
}
