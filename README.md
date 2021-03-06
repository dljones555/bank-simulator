bank-simulator
==============

Bank Simulator. Multithreaded .NET bank simulator written in C# with an object model containing 
customers, tellers, transactions, and a synchronized bank balance (vault). It was written while
I took C# II and III classes (circa 2007) at UCSD extension.

This was implemented using System.Threading. For the past year, in two different work
projects, I have used the Task Parallel Library (TPL) and asynchronous programming framework features
available in .NET 4.0 and 4.5.

I am releasing this to github, and envision an evolution of this program utilizing TPL, 
the producer-consumer pattern (customers would be producers, tellers consumers), BlockingCollection,
WPF for UI, etc.

Some excellent resources related to multithreading and concurrent programming in .NET:

Threading in C#, by Joe Albahari - free ebook
http://www.albahari.com/threading/

Stephen Cleary's blog - he is the author of O'Reilly's Concurrency in C# Cookbook
http://stephencleary.com


