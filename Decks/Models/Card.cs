using System;
using System.Collections.Generic;

namespace Decks.Models;

public partial class Card
{
    public long CardId { get; set; }

    public string? Front { get; set; }

    public string? Back { get; set; }

    public long? DeckId { get; set; }

    public long? TimesStudied { get; set; }

    public virtual Deck? Deck { get; set; }
}
