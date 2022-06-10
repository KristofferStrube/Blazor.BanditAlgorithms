# Blazor.BanditAlgorithms
A repository for exploring and visualizing bandit algorithms.

Bandit Algorithms is a familiy of algorithms that solve one common problem.

## Demo
The project can be demoed at [https://kristofferstrube.github.io/Blazor.BanditAlgorithms](https://kristofferstrube.github.io/Blazor.BanditAlgorithms/)

## The problem
The problem is imagined as having a slot-machine (bandit) with multiple arms. Each arm gives a reward. We wish to select (draw) a single arm in each round of the algorithm for which the slot-machine gives us some reward. The goal is then to minimize our regret over the number of rounds we play. The regret is defined as the difference between the reward of the arm we chose and the reward of the best arm we could have chosen.

## Rewards
The reward of each individual arm can be defined in different ways.
- The most basic is for the arm to always give the same reward, which is called the static setting.
- The reward can also be defined using some probability distribution, which is called a stochastic setting. One common example is to make a bernoulli trial with some mean value i.e. a coin-toss with some probability to hit head.
- The reward is adversarial. This is the worst we can imagine and we can imagine that reward can follow some complex pattern or potentially switch pattern/distribution over time.

## Algorithm goals
Many of the algorithms try to achieve what is called sub-linear regret. This means that we wish to make better and better choices over time.

To achieve this many of the algorithms builds on a principle of Exploiting the choices that we have seen as good previosly while Exploring options to see if other options have turned good over time.

## Goals
- Implement other Bandit algorithms
- Make datasets customizable
  - Add bernoulli arms
  - Add bernoulli arms with changing mean values
- Move the running of the algorithm to a web worker using the [Tewr.BlazorWorker](https://github.com/Tewr/BlazorWorker) package.
