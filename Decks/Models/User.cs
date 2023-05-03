using System;
using System.Collections.Generic;

namespace Decks.Models;

public partial class User
{
    public long UserId { get; set; }

    public string? Name { get; set; }

    public string? Password { get; set; }

/*    public virtual ICollection<Deck> Decks { get; set; } = new List<Deck>();

    public virtual ICollection<Progress> Progresses { get; set; } = new List<Progress>();*/
}
