import java.awt.*;

public class Rectangle {
    private int x1;
    private int y1;
    private int x2;
    private int y2;

    Rectangle(int x1, int y1, int x2, int y2) {
        this.x1 = x1;
        this.y1 = y1;
        this.x2 = x2;
        this.y2 = y2;
    }

    Rectangle(int width, int height) {
        this.x1 = 0;
        this.y1 = 0;
        this.x2 = width;
        this.y2 = height;
    }

    Rectangle() {
        this.x1 = 0;
        this.y1 = 0;
        this.x2 = 0;
        this.y2 = 0;
    }

    public void rectPrint() {
        System.out.printf("(%d,%d); (%d,%d)\n", x1, y1, x2, y2);
    }

    public void move(int dx, int dy) {
        x1 += dx;
        x2 += dx;
        y1 += dy;
        y2 += dy;
    }

    public void draw(Graphics g) {
    }

    public int[] getCoordinates() {
        return new int[]{this.x1, this.y1, this.x2, this.y2};
    }

    public Rectangle union(Rectangle rect) {
        return new Rectangle(x1, y1, rect.x2, rect.y2);
    }

    public int getX1() {
        return x1;
    }

    public int getY1() {
        return y1;
    }

    public int getX2() {
        return x2;
    }

    public int getY2() {
        return y2;
    }
}