import javax.swing.*;
import java.awt.*;

public class BouncingRectSimple {
    private static final int BOX_WIDTH = 640;
    private static final int BOX_HEIGHT = 480;

    Rectangle[] rects = {
            new Rectangle(10 + (int) (Math.random() * ((100 - 10) + 10)), 10 + (int) (Math.random() * ((100 - 10) + 10))),
            new Rectangle(10 + (int) (Math.random() * ((100 - 10) + 10)), 10 + (int) (Math.random() * ((100 - 10) + 10))),
            new Rectangle(10 + (int) (Math.random() * ((100 - 10) + 10)), 10 + (int) (Math.random() * ((100 - 10) + 10))),
            new Rectangle(10 + (int) (Math.random() * ((100 - 10) + 10)), 10 + (int) (Math.random() * ((100 - 10) + 10))),
            new Rectangle(10 + (int) (Math.random() * ((100 - 10) + 10)), 10 + (int) (Math.random() * ((100 - 10) + 10))),
            new Rectangle(10 + (int) (Math.random() * ((100 - 10) + 10)), 10 + (int) (Math.random() * ((100 - 10) + 10))),
            new Rectangle(10 + (int) (Math.random() * ((100 - 10) + 10)), 10 + (int) (Math.random() * ((100 - 10) + 10))),
            new Rectangle(10 + (int) (Math.random() * ((100 - 10) + 10)), 10 + (int) (Math.random() * ((100 - 10) + 10))),
            new Rectangle(10 + (int) (Math.random() * ((100 - 10) + 10)), 10 + (int) (Math.random() * ((100 - 10) + 10))),
            new Rectangle(10 + (int) (Math.random() * ((100 - 10) + 10)), 10 + (int) (Math.random() * ((100 - 10) + 10))),
            new ColoredRect(10 + (int) (Math.random() * ((100 - 10) + 10)), 10 + (int) (Math.random() * ((100 - 10) + 10))),
            new ColoredRect(10 + (int) (Math.random() * ((100 - 10) + 10)), 10 + (int) (Math.random() * ((100 - 10) + 10))),
            new ColoredRect(10 + (int) (Math.random() * ((100 - 10) + 10)), 10 + (int) (Math.random() * ((100 - 10) + 10))),
            new ColoredRect(10 + (int) (Math.random() * ((100 - 10) + 10)), 10 + (int) (Math.random() * ((100 - 10) + 10))),
            new ColoredRect(10 + (int) (Math.random() * ((100 - 10) + 10)), 10 + (int) (Math.random() * ((100 - 10) + 10))),
            new ColoredRect(10 + (int) (Math.random() * ((100 - 10) + 10)), 10 + (int) (Math.random() * ((100 - 10) + 10))),
            new ColoredRect(10 + (int) (Math.random() * ((100 - 10) + 10)), 10 + (int) (Math.random() * ((100 - 10) + 10))),
            new ColoredRect(10 + (int) (Math.random() * ((100 - 10) + 10)), 10 + (int) (Math.random() * ((100 - 10) + 10))),
            new ColoredRect(10 + (int) (Math.random() * ((100 - 10) + 10)), 10 + (int) (Math.random() * ((100 - 10) + 10))),
            new ColoredRect(10 + (int) (Math.random() * ((100 - 10) + 10)), 10 + (int) (Math.random() * ((100 - 10) + 10))),
            new DrawableRect(10 + (int) (Math.random() * ((100 - 10) + 10)), 10 + (int) (Math.random() * ((100 - 10) + 10))),
            new DrawableRect(10 + (int) (Math.random() * ((100 - 10) + 10)), 10 + (int) (Math.random() * ((100 - 10) + 10))),
            new DrawableRect(10 + (int) (Math.random() * ((100 - 10) + 10)), 10 + (int) (Math.random() * ((100 - 10) + 10))),
            new DrawableRect(10 + (int) (Math.random() * ((100 - 10) + 10)), 10 + (int) (Math.random() * ((100 - 10) + 10))),
            new DrawableRect(10 + (int) (Math.random() * ((100 - 10) + 10)), 10 + (int) (Math.random() * ((100 - 10) + 10))),
            new DrawableRect(10 + (int) (Math.random() * ((100 - 10) + 10)), 10 + (int) (Math.random() * ((100 - 10) + 10))),
            new DrawableRect(10 + (int) (Math.random() * ((100 - 10) + 10)), 10 + (int) (Math.random() * ((100 - 10) + 10))),
            new DrawableRect(10 + (int) (Math.random() * ((100 - 10) + 10)), 10 + (int) (Math.random() * ((100 - 10) + 10))),
            new DrawableRect(10 + (int) (Math.random() * ((100 - 10) + 10)), 10 + (int) (Math.random() * ((100 - 10) + 10))),
            new DrawableRect(10 + (int) (Math.random() * ((100 - 10) + 10)), 10 + (int) (Math.random() * ((100 - 10) + 10)))
    };

    private static final int UPDATE_RATE = 60; // Number of refresh per second

    /**
     * Constructor to create the UI components and init game objects.
     */
    public BouncingRectSimple() {
        this.setPreferredSize(new Dimension(BOX_WIDTH, BOX_HEIGHT));

        for (first.Rectangle rect : rects) {
            Thread gameThread = new Thread() {
                public void run() {
                    while (true) { // Execute one update step
                        // Calculate the rect's new position
                        rect.move((int) rect.speedX, (int) rect.speedY);
                        // Check if the rect moves over the bounds
                        // If so, adjust the position and speed.
                        if (rect.x1 < 0) {
                            rect.speedX = -rect.speedX; // Reflect along normal
                            rect.move((int) rect.speedX, (int) rect.speedY);
                        } else if (rect.x2 > BOX_WIDTH) {
                            rect.speedX = -rect.speedX;
                            rect.move((int) rect.speedX, (int) rect.speedY);
                        }
                        // May cross both x and y bounds
                        if (rect.y1 < 0) {
                            rect.speedY = -rect.speedY;
                            rect.move((int) rect.speedX, (int) rect.speedY);

                        } else if (rect.y2 > BOX_HEIGHT) {
                            rect.speedY = -rect.speedY;
                            rect.move((int) rect.speedX, (int) rect.speedY);
                        }
                        // Refresh the display
                        repaint(); // Callback paintComponent()
                        // Delay for timing control and give other threads a chance
                        try {
                            Thread.sleep(1000 / UPDATE_RATE);  // milliseconds
                        } catch (InterruptedException ex) {
                        }
                    }
                }
            };
            gameThread.start();  // Callback run()
        }
    }

    /**
     * Custom rendering codes for drawing the JPanel
     */
    @Override
    public void paintComponent(Graphics g
    ) {
        super.paintComponent(g);

        g.setColor(Color.white);
        g.fillRect(0, 0, BOX_WIDTH, BOX_HEIGHT);
        for (first.Rectangle rect : rects) {
            rect.draw(g);
        }
    }

    /**
     * main program (entry point)
     */
    public static void main(String[] args) {
        // Run GUI in the Event Dispatcher Thread (EDT) instead of main thread.
        javax.swing.SwingUtilities.invokeLater(new Runnable() {
            public void run() {
                // Set up main window (using Swing's Jframe)
                JFrame frame = new JFrame("Rectangles");
                frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
                frame.setContentPane(new BouncingRectSimple());
                frame.pack();
                frame.setVisible(true);
            }
        });
    }
}
