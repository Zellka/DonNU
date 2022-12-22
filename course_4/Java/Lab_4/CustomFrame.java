import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.Random;

public class CustomFrame extends JFrame implements ActionListener {

    JButton btnCreateRectangle, btnCreateDrawableRect, btnColoredRect;

    float r, g, b;

    public CustomFrame() {
        super("Лаба №4");
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        JPanel mainPanel = new JPanel();
        mainPanel.setLayout(new BorderLayout());

        GraphicPanel graphicPanel = new GraphicPanel();
        graphicPanel.setMinimumSize(new Dimension(this.getWidth(), 100));

        JPanel buttonsPanel = new JPanel();
        buttonsPanel.setLayout(new GridLayout(3, 1));

        btnCreateRectangle = new JButton("Create Rectangle");
        btnCreateDrawableRect = new JButton("Create DrawableRect");
        btnColoredRect = new JButton("Create ColoredRect");

        addActionListeners(graphicPanel);

        setDesignButtons();

        buttonsPanel.add(btnCreateRectangle);
        buttonsPanel.add(btnCreateDrawableRect);
        buttonsPanel.add(btnColoredRect);

        mainPanel.add(buttonsPanel, BorderLayout.EAST);
        mainPanel.add(graphicPanel, BorderLayout.CENTER);

        getContentPane().add(mainPanel);
    }

    private void addActionListeners(GraphicPanel graphPanel) {
        btnCreateRectangle.addActionListener((ActionEvent e) -> {
            graphPanel.addRectangle(new Rectangle(RandomInt(), RandomInt()));
        });
        btnCreateDrawableRect.addActionListener((ActionEvent e) -> {
            DrawableRect rect = new DrawableRect(RandomInt(), RandomInt());
            rect.setOutColor(RandomColor());
            graphPanel.addRectangle(rect);
            repaint();
        });
        btnColoredRect.addActionListener((ActionEvent e) -> {
            ColoredRect rect = new ColoredRect(RandomInt(), RandomInt());
            rect.setOutColor(RandomColor());

            graphPanel.addRectangle(rect);
            repaint();
        });
    }

    private void setDesignButtons() {
        btnCreateRectangle.setPreferredSize(new Dimension(440, 20));
        btnCreateDrawableRect.setPreferredSize(new Dimension(440, 20));
        btnColoredRect.setPreferredSize(new Dimension(440, 20));

        btnCreateRectangle.setBackground(Color.BLACK);
        btnCreateDrawableRect.setBackground(Color.RED);
        btnColoredRect.setBackground(Color.BLUE);
    }

    private int RandomInt() {
        return 10 + (int) (Math.random() * ((100 - 10) + 10));
    }

    private Color RandomColor() {
        Random random = new Random();
        r = random.nextFloat();
        g = random.nextFloat();
        b = random.nextFloat();
        return new Color(r, g, b);
    }

    @Override
    public void actionPerformed(ActionEvent e) {
    }
}
