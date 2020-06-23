# Chapter 6
## Our second external client
**Ecosystem / Versioning / CI**

-----
Our second client has different types of contracts that need to be considered. Having 2 clients that need to run the same code, but to work differently it is a challenging task. Thus, we could address this problem using two approaches:
1. Create a different branch for each client
2. Have a single branch of code, but allow through configuration to work differently
There is no perfect or easy solution, so let’s make a comparison and see which one fits better

## Organizing source code
There are two approaches to this problem: create separate branches for each client or use a single branch and make the product behave differently.

### Create different branches
So, we have our main code in master, and we will create a separate branch for each client. This is an easy task, but let’s see what are the consequences
*Advantages*
1. Creating a separate branch is no effort
1. Best way to separate behavior and replicate bugs
1. It is easy to implement a new different feature for each client
*Problems*
1. ~~IF~~  When a bug appears, it should be replicated on every client. This could be done by either 
have a single master and replicating to each branch
1. writing the bug solving code on every branch
1. Same with a new feature that many clients want.
1. The master branch will not have defined behavior. It will contain all the features merged, thus we should treat it as a new client, but with all features on.
### Create a single branch
Another solution is to have a single code branch, but this means to design the application to allow enabling/disabling features by configuration.

*Advantages*
1. Single branch to maintain
1. Fixing a bug => it is done in a single branch

*Problems*
1. Re-architecting the application to support different features per configuration.
1. Replicate the client behavior is more difficult
1. Create a feature requires more time to integrate with the configuration system
1. Components per client
1. Incompatible clients requirements ;-)


## Product client version
When a client reports a bug, we must know the code that was compiled to be distributed to the client. For this, we should somehow mark the source code before the application distributable to be built - and this can be done by tagging or by branches in the code source.
Also, we can have the application reporting the version of the components.


## Technical Box

1.  To organize to on single source code for multiple clients and different needs, please read Strategy Design Pattern - https://www.tutorialspoint.com/design_pattern/strategy_pattern.htm . Also you may use Plugin architecture - each client is a different plugin into the application .
1.  Versioning - show the production version. You can use  Semantic Versioning or Calendar Versioning. https://sachabarbs.wordpress.com/2020/02/23/net-core-standard-auto-incrementing-versioning/
2.  For Auto-Update application please read how it is done with  Click Once, Electron.
3.  For deploying / download the whole application please read .NET Core 3 Self Container Application per platform: https://docs.microsoft.com/en-us/dotnet/core/deploying/
