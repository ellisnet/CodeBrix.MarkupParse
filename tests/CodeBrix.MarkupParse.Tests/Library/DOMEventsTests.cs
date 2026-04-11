using System.Threading.Tasks;
using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Dom.Events;
using CodeBrix.MarkupParse.Html.Dom.Events;
using Xunit;

namespace CodeBrix.MarkupParse.Tests.Library; //Was previously: namespace AngleSharp.Core.Tests.Library

public class DOMEventsTests
{
    private IDocument document;

    public DOMEventsTests()
    {
        var source = @"<!doctype html>
<body>
<div id=first>
<span>
<img />
</span>
</div>
<div id=second>
</div>
</body>";
        document = source.ToHtmlDocument();
    }

    [Fact]
    public void EventsAddHandler()
    {
        var evName = "click";
        var element = document.QuerySelector("img");
        var args = document.CreateEvent("event");
        args.Init(evName, true, true);
        var count = 0;
        DomEventHandler listener1 = (_, _) => count++;
        element.AddEventListener(evName, listener1);
        element.Dispatch(args);
        Assert.Equal(1, count);
        Assert.Equal(evName, args.Type);
        Assert.False(args.IsTrusted);
    }

    [Fact]
    public async Task EventsAwaitedTriggered()
    {
        var evName = "click";
        document.QuerySelector("img");
        var ev = document.CreateEvent("event");
        ev.Init(evName, true, true);
        var task = document.AwaitEventAsync(evName);
        Assert.False(task.IsCompleted);
        document.Dispatch(ev);
        Assert.True(task.IsCompleted);
        Assert.False(task.IsFaulted);
        var result = await task;
        Assert.Equal(evName, result.Type);
    }

    [Fact]
    public void EventsRemoveHandler()
    {
        var evName = "click";
        var element = document.QuerySelector("img");
        var args = document.CreateEvent("event");
        args.Init(evName, true, true);
        var count = 0;
        DomEventHandler listener1 = (_, _) => count++;
        element.AddEventListener(evName, listener1);
        element.RemoveEventListener(evName, listener1);
        element.Dispatch(args);
        Assert.Equal(0, count);
        Assert.Equal(evName, args.Type);
        Assert.False(args.IsTrusted);
    }

    [Fact]
    public void EventsCapturingDispatchHandler()
    {
        var evName = "click";
        var element = document.QuerySelector("img");
        var args = document.CreateEvent("event");
        var beforeOther = true;
        args.Init(evName, true, true);
        DomEventHandler listener1 = (_, ev) =>
        {
            Assert.Equal(evName, ev.Type);
            Assert.Equal(EventPhase.AtTarget, ev.Phase);
            Assert.Equal(element, ev.CurrentTarget);
            Assert.Equal(element, ev.OriginalTarget);
            Assert.False(beforeOther);
        };
        DomEventHandler listener2 = (_, ev) =>
        {
            Assert.Equal(evName, ev.Type);
            Assert.Equal(EventPhase.Capturing, ev.Phase);
            Assert.Equal(element.Parent, ev.CurrentTarget);
            Assert.Equal(element, ev.OriginalTarget);
            beforeOther = false;
        };
        element.AddEventListener(evName, listener1);
        element.Parent.AddEventListener(evName, listener2, true);
        element.Dispatch(args);
    }

    [Fact]
    public void EventsBubblingDispatchHandler()
    {
        var evName = "click";
        var element = document.QuerySelector("img");
        var args = document.CreateEvent("event");
        var beforeOther = true;
        args.Init(evName, true, true);

        void listener1(object s, Event ev)
        {
            Assert.Equal(evName, ev.Type);
            Assert.Equal(EventPhase.AtTarget, ev.Phase);
            Assert.Equal(element, ev.CurrentTarget);
            Assert.Equal(element, ev.OriginalTarget);
            Assert.True(beforeOther);
        }

        void listener2(object s, Event ev)
        {
            Assert.Equal(evName, ev.Type);
            Assert.Equal(EventPhase.Bubbling, ev.Phase);
            Assert.Equal(element.Parent, ev.CurrentTarget);
            Assert.Equal(element, ev.OriginalTarget);
            beforeOther = false;
        }
        element.AddEventListener(evName, listener1);
        element.Parent.AddEventListener(evName, listener2);
        element.Dispatch(args);
    }

    [Fact]
    public void EventsCustomHandlerViaFactory()
    {
        var evName = "myevent";
        var element = document.QuerySelector("img");
        var args = document.CreateEvent("customevent") as CustomEvent;
        Assert.NotNull(args);
        var mydetails = new object();
        args.Init(evName, true, true, mydetails);
        DomEventHandler listener = (_, ev) =>
        {
            Assert.Equal(args, ev);
            Assert.Equal(evName, ev.Type);
            Assert.Equal(EventPhase.AtTarget, ev.Phase);
            Assert.Equal(element, ev.CurrentTarget);
            Assert.Equal(element, ev.OriginalTarget);
            Assert.Equal(mydetails, args.Details);
        };
        element.AddEventListener(evName, listener);
        element.Dispatch(args);
    }

    [Fact]
    public void EventsCustomHandlerViaConstructor()
    {
        var evName = "myevent";
        var element = document.QuerySelector("img");
        var args = new CustomEvent();
        var mydetails = new object();
        args.Init(evName, true, true, mydetails);
        DomEventHandler listener = (_, ev) =>
        {
            Assert.Equal(args, ev);
            Assert.Equal(evName, ev.Type);
            Assert.Equal(EventPhase.AtTarget, ev.Phase);
            Assert.Equal(element, ev.CurrentTarget);
            Assert.Equal(element, ev.OriginalTarget);
            Assert.Equal(mydetails, args.Details);
        };
        element.AddEventListener(evName, listener);
        element.Dispatch(args);
    }

    [Fact]
    public void EventsFactory()
    {
        var factory = new DefaultEventFactory();
        var invalid = factory.Create("invalid");
        var @event = factory.Create("event");
        var events = factory.Create("events");
        var wheelevent = factory.Create("wheelevent");

        Assert.Null(invalid);
        Assert.NotNull(@event);
        Assert.NotNull(events);
        Assert.NotNull(wheelevent);

        Assert.IsAssignableFrom<Event>(@event);
        Assert.IsAssignableFrom<Event>(events);
        Assert.IsAssignableFrom<WheelEvent>(wheelevent);
    }

    [Fact]
    public void EventsDocumentFinished()
    {
        document.ReadyStateChanged += (_, _) =>
        {
            Assert.Equal(DocumentReadyState.Complete, document.ReadyState);
        };

        document.Loaded += (_, _) =>
        {
            Assert.NotEqual(DocumentReadyState.Complete, document.ReadyState);
        };
    }
}
