﻿namespace Lifti
{
    public class IndexOptions
    {
        internal IndexOptions()
        {
        }

        /// <summary>
        /// Gets the depth of the index tree after which intra-node text is supported.
        /// A value of zero indicates that intra-node text is always supported. To disable
        /// intra-node text completely, set this to an arbitrarily large value, e.g. <see cref="Int32.MaxValue"/>.
        /// </summary>
        public int SupportIntraNodeTextAfterIndexDepth { get; internal set; } = 4;

        /// <summary>
        /// Gets the behavior the index should exhibit when an item that already exists in the index is indexed again. 
        /// The default value is <see cref="DuplicateItemBehavior.ReplaceItem"/>.
        /// </summary>
        public DuplicateItemBehavior DuplicateItemBehavior { get; internal set; } = DuplicateItemBehavior.ReplaceItem;
    }
}
