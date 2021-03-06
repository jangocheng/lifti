﻿using Lifti.Tokenization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lifti.ItemTokenization
{
    public class AsyncStringArrayReaderFieldTokenizationOptions<TItem> : FieldTokenizationOptions<TItem>
    {
        private readonly Func<TItem, Task<IEnumerable<string>>> reader;

        internal AsyncStringArrayReaderFieldTokenizationOptions(string name, Func<TItem, Task<IEnumerable<string>>> reader, TokenizationOptions? tokenizationOptions = null)
            : base(name, tokenizationOptions)
        {
            this.reader = reader ?? throw new ArgumentNullException(nameof(reader));
        }

        internal override async ValueTask<IEnumerable<Token>> TokenizeAsync(ITokenizer tokenizer, TItem item)
        {
            return tokenizer.Process(await this.reader(item).ConfigureAwait(false));
        }

        internal override IEnumerable<Token> Tokenize(ITokenizer tokenizer, TItem item)
        {
            throw new LiftiException(ExceptionMessages.AsyncAddMethodsMustBeUsed);
        }
    }
}