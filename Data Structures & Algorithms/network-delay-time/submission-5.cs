public class Solution {

    public int NetworkDelayTime(int[][] times, int n, int k) {

        var path = new List<(int to, int time)>[n + 1];
        for(int i = 1; i <= n; i++)
        {
            path[i] = new List<(int to, int time)>();
        }

        for(int i = 0; i < times.Length; i++)
        {
            var source = times[i][0];
            path[source].Add(new (times[i][1], times[i][2]));
        }

        var queue = new PriorityQueue<int, int>();
        queue.Enqueue(k, 0);

        bool[] visited = new bool[n+1];
        visited[0] = true;

        while(queue.TryDequeue(out int source, out int priority))
        {
            if (visited[source])
            {
                continue;
            }
            else
            {
                visited[source] = true;
            }

            if(visited.All(v => v == true))
            {
                return priority;
            }

            foreach(var target in path[source])
            {
                if(visited[target.to])
                {
                    continue;
                }

                queue.Enqueue(target.to, target.time + priority);
            }
        }

        return -1;
    }
}
