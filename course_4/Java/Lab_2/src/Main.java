class Main {

    public static void main(String[] args) {
        Rectangle rect1 = new Rectangle(0, 1, 2, 5);
        Rectangle rect2 = new Rectangle(150, 230);
        Rectangle rect3 = new Rectangle();
        rect1.rectPrint();
        rect2.rectPrint();
        rect3.rectPrint();

        System.out.println("Перемещение");
        rect1.move(7, 5);
        rect2.move(10, 2);
        rect3.move(60, 50);

        rect1.rectPrint();
        rect2.rectPrint();
        rect3.rectPrint();

        System.out.println("Объединение");
        Rectangle rectUnion = rect1.union(rect2);
        rectUnion.rectPrint();
    }
}
