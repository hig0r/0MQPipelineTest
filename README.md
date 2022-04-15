# 0MQ Pipeline Test
This project consists of: 
- A ventilator to generate numbers from 0 to 100.000;
- 1 or more workers to test if the number is prime (not optimized);
- A sink which will receive the prime numbers and print them to the console along with the elapsed time.

## Results
1 worker = 3928 ms
4 workers = 2391 ms

## Based on
https://zguide.zeromq.org/docs/chapter1/