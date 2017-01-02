#ifndef NOTEDVIEWER_H
#define NOTEDVIEWER_H

#include <QMainWindow>
#include <QFileDialog>
#include <QtSql/QSqlDatabase>
#include <QtSql/QSqlQuery>
#include <QStringListModel>
#include <QListWidgetItem>

namespace Ui {
class NotedViewer;
}

class NotedViewer : public QMainWindow
{
    Q_OBJECT

public:
    explicit NotedViewer(QWidget *parent = 0);
    ~NotedViewer();

private slots:
    void on_browseButton_clicked();

    void on_categoriesList_itemClicked(QListWidgetItem *item);

    void on_notesList_itemClicked(QListWidgetItem *item);

private:
    Ui::NotedViewer *ui;
    QSqlDatabase db;
    QString categorySelected;
};

#endif // NOTEDVIEWER_H
