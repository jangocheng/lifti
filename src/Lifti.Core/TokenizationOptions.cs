﻿using Lifti.Tokenization;
using System;
using System.Collections.Generic;

namespace Lifti
{
    public class TokenizationOptions
    {
        private bool caseInsensitive = true;
        private bool accentInsensitive = true;

        public TokenizationOptions(TokenizerKind tokenizerKind)
        {
            this.TokenizerKind = tokenizerKind;
        }

        /// <summary>
        /// Gets the default configuration of <see cref="TokenizationOptions"/>. This provides a tokenizer that
        /// is accent and case insensitive that splits on punctuation and whitespace, but does <b>not</b> perform word stemming.
        /// </summary>
        public static TokenizationOptions Default { get; } = new TokenizationOptions(TokenizerKind.PlainText);

        /// <summary>
        /// Gets the kind of tokenizer that should be used to read from any provided text.
        /// </summary>
        public TokenizerKind TokenizerKind { get; internal set; }

        /// <summary>
        /// Gets or sets a value indicating whether tokens should be split on punctuation in addition to standard 
        /// separator characters. Defaults to <c>true</c>.
        /// </summary>
        public bool SplitOnPunctuation { get; internal set; } = true;

        /// <summary>
        /// Gets or sets any additional characters that should cause tokens to be split. Defaults to an empty array.
        /// </summary>
        public IReadOnlyList<char> AdditionalSplitCharacters { get; internal set; } = Array.Empty<char>();

        /// <summary>
        /// Gets or sets a value indicating whether case insensitivity should be enforced when tokenizing. Defaults to <c>true</c>.
        /// </summary>
        public bool CaseInsensitive
        {
            get => this.caseInsensitive || this.Stemming;
            internal set => this.caseInsensitive = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether accents should be stripped from characters when tokenizing. Defaults to <c>true</c>.
        /// </summary>
        public bool AccentInsensitive
        {
            get => this.accentInsensitive || this.Stemming;
            internal set => this.accentInsensitive = value;
        }


        /// <summary>
        /// Gets or sets a value indicating whether word stemming should be applied when tokenizing. Setting this value to true 
        /// forces both <see cref="CaseInsensitive"/> and <see cref="AccentInsensitive"/> to be <c>true</c>.
        /// </summary>
        public bool Stemming { get; internal set; }
    }
}
