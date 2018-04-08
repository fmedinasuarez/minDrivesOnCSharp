Problem Statement

As of late, your usually high-performance computer has been acting rather sluggish. You come to
realize that while you have plenty of free disk space on your machine, it is split up over many hard
drives. You decide that the secret to improving performance is to consolidate all the data on your
computer onto as few hard drives as possible.
Given a int[] used, representing the amount of disk space used on each drive, and a corresponding
int[] total , representing the total capacity of each drive mentioned in used, you should return the
minimum number of hard drives needed to store the data after the consolidation is complete. You
may assume that the data consists of very small files, such that splitting it up and moving parts of it
onto different hard drives never presents a problem.
Definition

Class: DiskSpace

Method signature: public int minDrives(int[] used, int[] total)

Constraints
- used will contain between 1 and 50 elements, inclusive.
- used and total will contain the same number of elements.
- Each element of used will be between 1 and 1000, inclusive.
- Each element of total will be between 1 and 1000, inclusive.
- used[i] will always be less than or equal to total[i], for every valid index i. 
