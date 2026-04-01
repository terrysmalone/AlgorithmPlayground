using System;
using System.Collections.Generic;
using System.Text;

namespace MiniMaxAlgoritm;

public record struct TranspositionEntry(int Score, int Depth, EntryType Type);
