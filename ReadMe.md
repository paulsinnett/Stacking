# 2D Line to line collision

A common problem in games is to determine if something will hit something else. Often both things are in motion at the same time. There are a number of known solutions to this problem and in the past I have been happy enough to copy across the solution and carry on. However, since I tell my students to try to understand things well enough to explain them to someone else, I wanted to fully understand a solution.

There are a number of algebraic methods which are easy enough to do, but they are difficult to describe because algebra is often so abstract. So I spent some time looking at this problem from a pure geometric perspective.

This problem can be divided into two sub problems. The first begin, can you detect if two line will cross at all, and the second if they do cross, where do they cross each line.

# Do two lines cross?

In 2D two lines will always cross at some point, unless they are parallel. If they are parallel and separate, they will never cross. If they are co-incident touch at all points.

The first thing that struck me when thinking about this was given two lines represented by vectors I could define a parallelogram. If that parallelogram had no area, then the lines must be parallel, otherwise they  must cross. And it turns out that given two vectors (Ax, Ay) and (Bx, By), there is a formula for working out the area.

area = Ax * By - Bx * Ay

Again, I would usually take this on trust and move on. But this time I thought it might be enlightening to show why this must be true. Looking at the formula, it is saying that given a parallelogram. It must be possible cut it up and re-arrange it to fit an area which is the difference of two rectangles; that is, the area left over when one rectangle is subtracted from another.

This is complicated slightly by the fact that either or both of the rectangles could have a negative area. The idea of a negative area is not something we usually consider since we don't usually use signed values for the edges of rectangles, but as we are converting vectors into rectangles it's possible we could one negative edge and one positive. This would result in a negative area. So either of our rectangles could be positive or negative. If our first rectangle is positive and our second is negative, or if our first is negative and our second is positive, then these reactangle will add together rather than subtract due to the normal rules for subtracting negative numbers. But either way, the final result, whether positive or negative will provide an area into which we should always be able to fit our parallelogram.

The next problem is that it is possible, depending on the vectors chosen, to get two rectangles that will not neatly subtract from one another as rectangles. This will happen if the width of your second rectangle is longer than the width of your first, but the height of your second is shorter than your first. This will leave a remainder which you will then have to remove from the result. An alternative which will always avoid this problem is to resize the second rectangle such that its width or height matches that of the first. If you want the rectangle Bx * Ay to have the same width as the rectangle Ax * By, then you can multiply the width by Bx / Ax and multiply the height by Ax / Bx. (If you scale the width up by some amount you must scale the height down by the same fraction and flipping the fraction Bx / Ax to Ax / Bx does that for you.) Note that this adjustment is only necessary for the purposes of visualisation, it doesn't change the area required.

With those two complications aside, we now have a fairly simple puzzle to solve. I tried resolving this for some time by trying to cut the rectangles and turn them into parallelograms. And also trying to cut the parallelograms into rectangles. Although, according to the formula this should be possible, it often required making unintuitive cuts and it was not always obvious that the two figures retained the same area throughout the transformation. However, after some trial, and a lot of error, I worked out a way to show that the areas were equal by cutting out and moving two triangular shapes. The trick, it turned out was not to try to transform the parallelogram into the rectangles, but instead to enclose the parallelogram in a larger rectangle, and move the surrounding shapes until it encloses the rectangles we are looking for.

