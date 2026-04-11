using System;
using System.Collections;
using System.Collections.Generic;

namespace CodeBrix.MarkupParse.Io.Dom; //Was previously: namespace AngleSharp.Io.Dom

/// <summary>
/// Represents a container for file entries captured by the file
/// upload field.
/// </summary>
sealed class FileList : IFileList
{
    #region Fields

    private readonly List<IFile> _entries;

    #endregion

    #region ctor

    internal FileList()
    {
        _entries = [];
    }

    #endregion

    #region Index

    public IFile this[int index] => _entries[index];

    #endregion

    #region Properties

    public int Length => _entries.Count;

    #endregion

    #region Methods

    public void Add(IFile item) => _entries.Add(item);

    public void Clear() => _entries.Clear();

    public bool Remove(IFile item) => _entries.Remove(item);

    #endregion

    #region IEnumerable Implementation

    public IEnumerator<IFile> GetEnumerator() => _entries.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    #endregion
}
