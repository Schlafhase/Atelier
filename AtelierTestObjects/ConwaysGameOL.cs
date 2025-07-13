using Atelier.Interfaces;
using Raylib_cs;
using Vectors;

namespace AtelierTestObjects;

public class ConwaysGameOL : AObject
{
    public HashSet<(int x, int y)> Occupied { get; set; } = [(0,0), (0,1), (1, 0), (1, 1)];
    public bool Paused { get; set; }

    private double _timeSinceLastUpdate = 0;
    
    
    public override void Tick(double dt = 16.6)
    {
        if (Paused)
        {
            return;
        }
        
        _timeSinceLastUpdate += dt;
        if (_timeSinceLastUpdate < 100)
        {
            return;
        }
        _timeSinceLastUpdate = 0;
        
        HashSet<(int x, int y)> newState = [];
        
        foreach ((int x, int y) in Occupied)
        {
            int liveNeighbors = countLiveNeighbours(x, y, newState);

            if (liveNeighbors is >= 2 and <= 3)
            {
                // TODO: memor lek
                newState.Add((x, y));
            }
        }
        
        Occupied = newState;
    }

    private int countLiveNeighbours(int x, int y, HashSet<(int x, int y)> newState, bool liveCell = true)
    {
        int liveNeighbors = 0;

        for (int xNeighbour = -1; xNeighbour <= 1; xNeighbour++)
        {
            for (int yNeighbour = -1; yNeighbour <= 1; yNeighbour++)
            {
                if (xNeighbour == 0 && yNeighbour == 0)
                {
                    continue;
                }

                if (Occupied.Contains((x + xNeighbour, y + yNeighbour)))
                {
                    liveNeighbors++;
                }
                else if (liveCell)
                {
                    int neighboursLiveNeighbours = countLiveNeighbours(x + xNeighbour, y + yNeighbour, newState, false);
                    
                    if (neighboursLiveNeighbours == 3)
                    {
                        newState.Add((x + xNeighbour, y + yNeighbour));
                    }
                }
            }
        }

        return liveNeighbors;
    }

    public override void Render()
    {
        foreach ((int x, int y) in Occupied)
        {
            Raylib.DrawRectangle(x, y, 1, 1, Raylib.Fade(Color.SkyBlue, Paused ? 0.7f : 1));
        }
        
    }
}