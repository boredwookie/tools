#include "notedviewer.h"
#include <QApplication>

int main(int argc, char *argv[])
{
    QApplication a(argc, argv);
    NotedViewer w;
    w.show();

    return a.exec();
}
