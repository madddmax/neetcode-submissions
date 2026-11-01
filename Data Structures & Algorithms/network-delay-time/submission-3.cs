public class Solution {

    record Target(int Source, int Time);
    record Node(int Source, List<Target> TargetList); 

    public int NetworkDelayTime(int[][] times, int n, int k) {

        var path = new Dictionary<int, Node>(n);
        for(int i = 1; i <= n; i++)
        {
            path[i] = new Node(i, new List<Target>());
        }

        for(int i = 0; i < times.Length; i++)
        {
            var source = times[i][0];
            var target = new Target(times[i][1], times[i][2]);
            path[source].TargetList.Add(target);
        }

        var queue = new PriorityQueue<Node, int>();
        queue.Enqueue(path[k], 0);

        HashSet<int> visited = new HashSet<int>();

        while(queue.TryDequeue(out var node, out int priority))
        {
            if (!visited.Add(node.Source))
            {
                continue;
            }
            
            if(visited.Count == n)
            {
                return priority;
            }

            foreach(var target in node.TargetList)
            {
                if(visited.Contains(target.Source))
                {
                    continue;
                }

                queue.Enqueue(path[target.Source], target.Time + priority);
            }
        }

        return -1;
    }
}
