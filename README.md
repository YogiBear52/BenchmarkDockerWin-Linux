
**<span style="text-decoration:underline;">Containers - Windows vs Linux  + SIMD - Benchmark </span>**

**<span style="text-decoration:underline;">Base assumptions</span>**:



*   We want as few layers(OS) as possible from our App to the bare processor.
*   We want our layers(OS) to be as thin as possible.

     If we get to achieve these two things, our <span style="text-decoration:underline;">app will run faster</span>, and it will be <span style="text-decoration:underline;">easier</span> and      <span style="text-decoration:underline;">faster</span> to create a new instance of our App.

**<span style="text-decoration:underline;">History</span>**:



*   Docker containers has broke in to the world.
*   Containers don’t use another OS layer like the VM do, instead it isolates a process in the base OS. (from virtualization to containerization)
*   The linux market has taken the lead, of course, because it was easy to isolate a process compared to windows, and because linux has a bigger market share of the servers.
*   Windows was trying to chase the trend, and got it’s Hyper-V and Nano-server solutions for containerization.
*   Until that day, we all underestimate Windows solution for containers and choosing Linux containers solution as the default and ideal choice.

**<span style="text-decoration:underline;">What is missing in today’s benchmarks</span>**:



*   No benchmarks compare Windows base containers vs Linux base containers.
    *   Creation time of the containers.
    *   Overall performance.
*   No benchmarks compare SIMD technology on both Windows and Linux containers vs usual VMs.

**<span style="text-decoration:underline;">What I am going to study</span>**:



*   Is Windows solution for containers really bad? Maybe it’s even better in some cases. Let’s prove it for once and for all.
*   SIMD is a complex technology which uses the OS layer and the Processor layer.	
    *    Let’s make sure the containers on both Linux and Windows didn’t ruin the great performance of it.
    *   Usual benchmark to see if SIMD got even better with containers. 

**<span style="text-decoration:underline;">How it will be done</span>**:



*   Using Azure cloud for comparing Windows containers vs Linux containers.
*   Using C# benchmarking library. Why?
    *   I am very cofitable with C# and .Net.
    *   .Net Core is considered to be one of the most performance framework nowadays, thus the OS will be the focus and not the programming language performance.
    *   .Net Core supports SIMD technology, which will be part of the benchmark as well.

Yogev Mizrahi

References:



*   [https://medium.com/jettech/a-short-introduction-to-windows-containers-db5adc0db536](https://medium.com/jettech/a-short-introduction-to-windows-containers-db5adc0db536)
*   [https://www.phoronix.com/scan.php?page=article&item=docker-summer-2018&num=4](https://www.phoronix.com/scan.php?page=article&item=docker-summer-2018&num=4)

<!-- Docs to Markdown version 1.0β17 -->
