import java.awt.*;

public class ColoredRect extends DrawableRect {

    private Color inColor;

    ColoredRect() {
        super();
        inColor = Color.GRAY;
    }

    public ColoredRect(int width,int height){
        super(width,height);
        inColor = Color.BLUE;
    }

    public void draw(Graphics g) {
        super.draw(g);
        g.fillRect(getX1(), getY1(), getX2(), getY2());
        g.setColor(inColor);
    }
}
