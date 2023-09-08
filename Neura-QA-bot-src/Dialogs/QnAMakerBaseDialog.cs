// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.AI.QnA;
using Microsoft.Bot.Builder.AI.QnA.Dialogs;
using Microsoft.Bot.Builder.AI.QnA.Models;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;
using Microsoft.Extensions.Configuration;

namespace Microsoft.BotBuilderSamples.Dialogs
{
    /// <summary>
    /// QnAMaker action builder class
    /// </summary>
    public class QnAMakerBaseDialog : QnAMakerDialog
    {
        // Dialog Options parameters
        private readonly IBotServices _services;
        private readonly IConfiguration _configuration;

        public const string ActiveLearningCardTitle = "Did you mean:";
        public const string ActiveLearningCardNoMatchText = "None of the above.";
        public const string ActiveLearningCardNoMatchResponse = "Thanks for the feedback.";
        private readonly string DefaultAnswer = "";
        private bool _enablePreciseAnswer;
        private bool _displayPreciseAnswerOnly;
        private const bool _includeUnstructuredSources = true;
        private const float _scoreThreshold = 0.3f;
        private const int _topAnswers = 3;
        private const string _rankerType = "Default";
        private const bool _isTest = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="QnAMakerBaseDialog"/> class.
        /// Dialog helper to generate dialogs.
        /// </summary>
        /// <param name="services">Bot Services.</param>
        public QnAMakerBaseDialog(IBotServices services, IConfiguration configuration) : base()
        {
            this._configuration = configuration;
            this._services = services;

            if (!string.IsNullOrWhiteSpace(configuration["DefaultAnswer"]))
            {
                this.DefaultAnswer = configuration["DefaultAnswer"];
            }

            if (!string.IsNullOrWhiteSpace(configuration["EnablePreciseAnswer"]))
            {
                _enablePreciseAnswer = bool.Parse(configuration["EnablePreciseAnswer"]);
            }

            if (!string.IsNullOrWhiteSpace(configuration["DisplayPreciseAnswerOnly"]))
            {
                _displayPreciseAnswerOnly = bool.Parse(configuration["DisplayPreciseAnswerOnly"]);
            }
        }

        protected async override Task<IQnAMakerClient> GetQnAMakerClientAsync(DialogContext dc)
        {
            return _services?.QnAMakerService;
        }

        protected override Task<QnAMakerOptions> GetQnAMakerOptionsAsync(DialogContext dc)
        {
            return Task.FromResult(new QnAMakerOptions
            {
                ScoreThreshold = _scoreThreshold,
                Top = _topAnswers,
                QnAId = 0,
                RankerType = _rankerType,
                IsTest = _isTest,
                EnablePreciseAnswer = _enablePreciseAnswer,
                IncludeUnstructuredSources = _includeUnstructuredSources,
                Filters = { }
            });
        }

        protected async override Task<QnADialogResponseOptions> GetQnAResponseOptionsAsync(DialogContext dc)
        {
            var defaultAnswerActivity = MessageFactory.Text(this.DefaultAnswer);

            var cardNoMatchResponse = (Activity)MessageFactory.Text(ActiveLearningCardNoMatchResponse);

            var responseOptions = new QnADialogResponseOptions
            {
                ActiveLearningCardTitle = ActiveLearningCardTitle,
                CardNoMatchText = ActiveLearningCardNoMatchText,
                NoAnswer = defaultAnswerActivity,
                CardNoMatchResponse = cardNoMatchResponse,
                DisplayPreciseAnswerOnly = _displayPreciseAnswerOnly
            };

            return responseOptions;
        }
    }
}
