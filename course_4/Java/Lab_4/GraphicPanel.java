import javax.swing.*;
import java.awt.*;
import java.awt.event.MouseAdapter;
import java.util.ArrayList;

public class GraphicPanel extends JPanel {

    private Point lastPosition = null;

    private Rectangle currentRect;

    private int mX;
    private int mY;

    private ArrayList<Rectangle> rectangles = new ArrayList<>();

    private boolean RectangleContains(Point p, Rectangle rect) {
        return p.x > rect.getCoordinates()[0] && p.y > rect.getCoordinates()[1] && p.x < rect.getCoordinates()[2] && p.y < rect.getCoordinates()[3];
    }

    @Override
    public void paintComponent(Graphics g) {
        super.paintComponent(g);
        g.setColor(Color.WHITE);
        g.fillRect(0, 0, getBounds().width, getBounds().width);
        for (Rectangle rect : rectangles) {
            rect.draw(g);
        }
    }

    private MouseAdapter mouseListener = new MouseAdapter() {
        public void mousePressed(java.awt.event.MouseEvent e) {
            Point p = e.getPoint();
            for (int i = rectangles.size() - 1; i >= 0; i--) {
                if (RectangleContains(p, rectangles.get(i))) {
                    currentRect = rectangles.get(i);
                    lastPosition = p;
                    break;
                }
            }
        }

        @Override
        public void mouseDragged(java.awt.event.MouseEvent e) {
            if (lastPosition != null) {
                ChangeColor();
                mX = (int) (e.getX() - lastPosition.x);
                mY = (int) (e.getY() - lastPosition.y);
                currentRect.move(mX, mY);
                lastPosition.x += mX;
                lastPosition.y += mY;
                repaint();
            }

        }

        @Override
        public void mouseReleased(java.awt.event.MouseEvent e) {
            Thread gameThread = new Thread() {
                public void run() {
                    for (int i = 0; i < 100; i++) {
                        currentRect.move(mX, mY);
                        boundsCheck();
                        repaint();
                        ChangeColor();
                        try {
                            Thread.sleep(1000 / 60);  // milliseconds
                        } catch (InterruptedException ex) {
                        }
                    }
                    lastPosition = null;
                }
            };
            gameThread.start();
        }
    };

    private void boundsCheck() {
        if (currentRect.getX1() < 0) {
            mX = -mX;
            currentRect.move(mX, mY);
        } else if (currentRect.getX2() > 900) {
            mX = -mX;
            currentRect.move(mX, mY);
        }
        if (currentRect.getY1() < 0) {
            mY = -mY;
            currentRect.move(mX, mY);
        } else if (currentRect.getY2() > 720) {
            mY = -mY;
            currentRect.move(mX, mY);
        }
    }

    private void ChangeColor() {
        if (currentRect instanceof ColoredRect) {
            if (currentRect.getY2() < 240) {
                ((ColoredRect) currentRect).setOutColor(Color.WHITE);
            }
            if (currentRect.getY2() > 240 && currentRect.getY2() < 480) {
                ((ColoredRect) currentRect).setOutColor(Color.BLUE);
            }
            if (currentRect.getY2() > 480) {
                ((ColoredRect) currentRect).setOutColor(Color.RED);
            }
        } else {
            if (currentRect.getY1() < 240) {
                ((ColoredRect) currentRect).setOutColor(Color.GRAY);
            }
            if (currentRect.getY1() > 240 && currentRect.getY1() < 480) {
                ((ColoredRect) currentRect).setOutColor(Color.BLUE);
            }
            if (currentRect.getY1() > 480) {
                ((ColoredRect) currentRect).setOutColor(Color.RED);
            }
        }
    }

    public void addRectangle(DrawableRect newRect) {
        rectangles.add(newRect);
    }

    public void addRectangle(ColoredRect newRect) {
        rectangles.add(newRect);
    }
}
