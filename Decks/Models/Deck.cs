using System;
using System.Collections.Generic;

namespace Decks.Models;

public partial class Deck
{
    public long DeckId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public long? UserId { get; set; }

    public long? TagId { get; set; }

/*    public virtual ICollection<Card> Cards { get; set; } = new List<Card>();

    public virtual Tag? Tag { get; set; }

    public virtual User? User { get; set; }*/
}
