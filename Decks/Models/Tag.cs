using System;
using System.Collections.Generic;

namespace Decks.Models;

public partial class Tag
{
    public long TagId { get; set; }

    public string? Name { get; set; }

/*    public virtual ICollection<Deck> Decks { get; set; } = new List<Deck>();*/
}
