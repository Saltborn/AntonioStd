﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntonioStd.Collections
{
    public interface ICollection<T> : IIterable<T>
    {
        int Count { get; }

        bool Contains(T value);

        T[] ToArray();

        bool IsEmprty();
    }
}
