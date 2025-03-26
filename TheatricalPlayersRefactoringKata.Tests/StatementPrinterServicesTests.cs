using System;
using System.Collections.Generic;
using System.Globalization;
using ApprovalTests;
using ApprovalTests.Reporters;
using Xunit;
using TheatricalPlayersRefactoringKata.Application.Services;
using TheatricalPlayersRefactoringKata.Domain.Entities;
using TheatricalPlayersRefactoringKata.Domain.Enums;

namespace TheatricalPlayersRefactoringKata.Tests
{
    public class StatementPrinterTests
    {
        private readonly Dictionary<string, Play> _plays;
        private readonly Invoice _invoice;
        private readonly CultureInfo _enUsCulture;
        private readonly StatementPrinterService _service;

        public StatementPrinterTests()
        {
            // Setup básico
            _enUsCulture = new CultureInfo("en-US");
            _service = new StatementPrinterService();

            // Cria plays de teste para os approval tests
            var hamletPlay = new Play("Hamlet", 4024, EPlayType.Tragedy);
            var asYouLikeItPlay = new Play("As You Like It", 2670, EPlayType.Comedy);
            var othelloPlay = new Play("Othello", 3560, EPlayType.Tragedy);
            var henryVPlay = new Play("Henry V", 3227, EPlayType.Historical);
            var johnPlay = new Play("King John", 2648, EPlayType.Historical);

            _plays = new Dictionary<string, Play>
            {
                { hamletPlay.Id.ToString(), hamletPlay },
                { asYouLikeItPlay.Id.ToString(), asYouLikeItPlay },
                { othelloPlay.Id.ToString(), othelloPlay },
                { henryVPlay.Id.ToString(), henryVPlay },
                { johnPlay.Id.ToString(), johnPlay }
            };

            // Cria performances para os approval tests
            var performances = new List<Performance>
            {
                new Performance(hamletPlay.Id, 55),
                new Performance(asYouLikeItPlay.Id, 35),
                new Performance(othelloPlay.Id, 40),
                new Performance(henryVPlay.Id, 20),
                new Performance(johnPlay.Id, 39),
                new Performance(henryVPlay.Id, 20)
            };

            // Cria invoice para os approval tests
            _invoice = new Invoice("BigCo", performances);
        }

        [Fact]
        [UseReporter(typeof(DiffReporter))]
        public void TestStatementExampleLegacy()
        {
            // Criando service e culture para o teste
            var service = new StatementPrinterService();
            var enUsCulture = new CultureInfo("en-US");

            // Criando peças com IDs específicos
            var hamletId = Guid.NewGuid();
            var asYouLikeItId = Guid.NewGuid();
            var othelloId = Guid.NewGuid();

            var hamletPlay = new Play("Hamlet", 4024, EPlayType.Tragedy);
            var asYouLikeItPlay = new Play("As You Like It", 2670, EPlayType.Comedy);
            var othelloPlay = new Play("Othello", 3560, EPlayType.Tragedy);

            // Criando dicionário com as peças
            var playsLegacy = new Dictionary<string, Play>
            {
                { hamletPlay.Id.ToString(), hamletPlay },
                { asYouLikeItPlay.Id.ToString(), asYouLikeItPlay },
                { othelloPlay.Id.ToString(), othelloPlay }
            };

                    // Criando performances que correspondem às peças
                    var performancesLegacy = new List<Performance>
            {
                new Performance(hamletPlay.Id, 55),
                new Performance(asYouLikeItPlay.Id, 35),
                new Performance(othelloPlay.Id, 40)
            };

            // Criando invoice
            var invoiceLegacy = new Invoice("BigCo", performancesLegacy);

            // Act
            var result = service.Print(invoiceLegacy, playsLegacy, EOutputType.Text, enUsCulture);

            // Assert
            Approvals.Verify(result);
        }

        [Fact]
        [UseReporter(typeof(DiffReporter))]
        public void TestTextStatementExample()
        {
            // Act
            var result = _service.Print(_invoice, _plays, EOutputType.Text, _enUsCulture);

            // Assert
            Approvals.Verify(result);
        }

        [Fact]
        [UseReporter(typeof(DiffReporter))]
        public void TestXmlStatementExample()
        {
            // Act
            var result = _service.Print(_invoice, _plays, EOutputType.XML, _enUsCulture);

            // Assert
            Approvals.Verify(result);
        }
    }
}