# Best practices - IDisposable pattern

## Purpose of IDisposable
> The IDisposable interface defines a single method, Dispose(), which is 
intended to release resources held by the object that implements the interface.
> Implement a Dispose method: https://learn.microsoft.com/en-us/dotnet/standard/garbage-collection/implementing-dispose

## Language support for IDisposable
> Disposable objects can release unmanaged resources early by using the
using statement with or without braces: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/using-statement
> Another approach is to call Dispose in a finally block in a try/catch/finally 
or try/finally statement: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/try-finally

## When to implement IDisposable
> If a class owns  field or a property of a disposable type, it should implement IDisposable
to allow deterministic release of unmanaged resources: https://learn.microsoft.com/en-us/dotnet/standard/garbage-collection/implementing-dispose#cascade-dispose-calls


## How to implement IDisposable
> The dispose pattern is very precise and notoriously difficult to implement correctly.
It should be implemented exactly as described on https://learn.microsoft.com/en-us/dotnet/standard/garbage-collection/implementing-dispose#implement-the-dispose-pattern
> A class implementing the dispose pattern should also implement the finalizer pattern. 
This ensures that Dispose() is called even if the client code forgets to call it explicitly.

## New in .NET 8: IAsyncDisposable
> The IAsyncDisposable interface defines a single method, DisposeAsync(), which is
called to release unmanaged resources asynchronously: 
https://learn.microsoft.com/en-us/dotnet/standard/garbage-collection/implementing-disposeasync
> A class that implements IDisposable can -- and typically should -- implement IAsyncDisposable as well:
https://learn.microsoft.com/en-us/dotnet/standard/garbage-collection/implementing-disposeasync#implement-both-dispose-and-async-dispose-patterns
> Async disposable objects are typically used in `await using` statements: 
https://learn.microsoft.com/en-us/dotnet/standard/garbage-collection/implementing-disposeasync#using-async-disposable


