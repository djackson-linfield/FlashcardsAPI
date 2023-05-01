using System;
using System.Collections.Generic;

namespace Decks.Models;

public partial class Progress
{
    public long ProgressId { get; set; }

    public long? UserId { get; set; }

    public long? DeckId { get; set; }

    public long? CardsStudied { get; set; }

    public long? CardsMastered { get; set; }

    public virtual User? User { get; set; }
}
