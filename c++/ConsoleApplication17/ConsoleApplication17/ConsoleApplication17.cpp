#include <iostream>
using namespace std;

struct Point {
    double x, y;

    Point(double x = 0, double y = 0) : x(x), y(y) {}
};

struct Line {
    Point start;
    Point end;

    Line(Point start = {}, Point end = {}) : start(start), end(end) {}
};

struct Shape {
    Line* lines;
    int lineCount;

    Shape(int lineCount) : lineCount(lineCount) {
        lines = new Line[lineCount];
    }

    ~Shape() {
        delete[] lines;
    }

    void setLine(int index, const Line& line) {
        if (index >= 0 && index < lineCount) {
            lines[index] = line;
        }
    }

    bool isClosed() const {
        if (lineCount == 0) return false;

        return lines[0].start.x == lines[lineCount - 1].end.x &&
            lines[0].start.y == lines[lineCount - 1].end.y;
    }
};

int main() {
    Point p1(0, 0);
    Point p2(1, 0);
    Point p3(1, 1);
    Point p4(0, 1);

    Line l1(p1, p2);
    Line l2(p2, p3);
    Line l3(p3, p4);
    Line l4(p4, p1);

    Shape shape(4);

    shape.setLine(0, l1);
    shape.setLine(1, l2);
    shape.setLine(2, l3);
    shape.setLine(3, l4);

    cout << "Is shape closed? " << (shape.isClosed() ? "Yes" : "No") << endl;

    return 0;
}
