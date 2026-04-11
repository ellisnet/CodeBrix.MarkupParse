using CodeBrix.MarkupParse.Dom.Events;
using System;

namespace CodeBrix.MarkupParse.Dom; //Was previously: namespace AngleSharp.Dom

/// <summary>
/// Defines the callback signature for an event.
/// </summary>
/// <param name="sender">The callback this argument.</param>
/// <param name="ev">The event arguments.</param>
public delegate void DomEventHandler(object sender, Event ev);
