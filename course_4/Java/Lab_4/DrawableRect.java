import java.awt.*;

public class DrawableRect extends Rectangle {

    private Color outColor;

    DrawableRect() {
        super();
        outColor = Color.RED;
    }

    public DrawableRect(int width,int height){
        super(width,height);
        outColor = Color.BLACK;
    }

    public void setOutColor(Color outColor) {
        this.outColor = outColor;
    }

    public void draw(Graphics g) {
        g.drawRect(getX1(), getY1(), getX2(), getY2());
        g.setColor(outColor);
    }
}
