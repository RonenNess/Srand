# Srand

Srand provides a `System.Random` implementation that will stay persistent across different OS and .net versions, and is easy to implement in different languages to maintain consistency (for example in JS for client side). 

It has similar performance to the built-in Random implementation (slightly slower for Next()), and should have similar strength in terms of randomness, which is good enough for fun and games, but not for cryptography.

In short, this is just an alternative to `System.Random` that will output the same sequence of numbers for the same seed, no matter where, when, and how you use it.
