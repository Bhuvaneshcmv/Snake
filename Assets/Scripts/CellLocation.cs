using System;

[Serializable]
public struct CellLocation
{
    int x;
    int y;
    int index;
    public CellLocation(int ix,int xPos,int yPos)
    {
        this.x= xPos; 
        this.y= yPos;
        this.index= ix;
    }
};
