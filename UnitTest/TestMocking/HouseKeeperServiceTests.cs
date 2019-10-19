﻿using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace UnitTest.TestMocking
{
    [TestFixture]
    public class HouseKeeperServiceTests
    {
        [Test]
        public void SendStatmentEmails_WhenCalled_GenerateStatements()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(uow => uow.Query<Housekeeper>()).Returns(new List<Housekeeper>
            {
                new Housekeeper{Email = "a",FullName = "b", Oid = 1, StatementEmailBody = "c"}
            }.AsQueryable());

            var statementGenerator = new Mock<IStatementGenerator>();
            var emailSender = new Mock<IEmailSender>();
            var messageBox = new Mock<IXtraMessageBox>();

            var service = new HousekeeperService(
                unitOfWork.Object,
                statementGenerator.Object,
                emailSender.Object,
                messageBox.Object);

            service.SendStatementEmails(new DateTime(2017, 1, 1));
            statementGenerator.Verify(sg => sg.SaveStatement(1, "b", (new DateTime(2017, 1, 1))));
        }
    }
}
