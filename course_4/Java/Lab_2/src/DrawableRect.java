import java.awt.*;

public class DrawableRect extends Rectangle {

    private Color outColor;

    DrawableRect() {
        super();
        outColor = Color.RED;
    }

    public void draw(Graphics g) {
        g.drawRect(getX1(), getY1(), getX2(), getY2());
        g.setColor(outColor);
    }
}
