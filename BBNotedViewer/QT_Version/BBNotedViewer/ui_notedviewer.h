/********************************************************************************
** Form generated from reading UI file 'notedviewer.ui'
**
** Created by: Qt User Interface Compiler version 5.7.1
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_NOTEDVIEWER_H
#define UI_NOTEDVIEWER_H

#include <QtCore/QVariant>
#include <QtWidgets/QAction>
#include <QtWidgets/QApplication>
#include <QtWidgets/QButtonGroup>
#include <QtWidgets/QHeaderView>
#include <QtWidgets/QLabel>
#include <QtWidgets/QLineEdit>
#include <QtWidgets/QListWidget>
#include <QtWidgets/QMainWindow>
#include <QtWidgets/QMenuBar>
#include <QtWidgets/QPushButton>
#include <QtWidgets/QStatusBar>
#include <QtWidgets/QTextEdit>
#include <QtWidgets/QToolBar>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_NotedViewer
{
public:
    QWidget *centralWidget;
    QLineEdit *nbakPath;
    QLabel *label;
    QPushButton *browseButton;
    QListWidget *categoriesList;
    QListWidget *notesList;
    QTextEdit *noteText;
    QLineEdit *noteTitle;
    QLabel *label_2;
    QLabel *label_3;
    QMenuBar *menuBar;
    QToolBar *mainToolBar;
    QStatusBar *statusBar;

    void setupUi(QMainWindow *NotedViewer)
    {
        if (NotedViewer->objectName().isEmpty())
            NotedViewer->setObjectName(QStringLiteral("NotedViewer"));
        NotedViewer->resize(800, 600);
        centralWidget = new QWidget(NotedViewer);
        centralWidget->setObjectName(QStringLiteral("centralWidget"));
        nbakPath = new QLineEdit(centralWidget);
        nbakPath->setObjectName(QStringLiteral("nbakPath"));
        nbakPath->setGeometry(QRect(75, 20, 251, 22));
        label = new QLabel(centralWidget);
        label->setObjectName(QStringLiteral("label"));
        label->setGeometry(QRect(10, 23, 61, 16));
        browseButton = new QPushButton(centralWidget);
        browseButton->setObjectName(QStringLiteral("browseButton"));
        browseButton->setGeometry(QRect(330, 20, 80, 22));
        categoriesList = new QListWidget(centralWidget);
        categoriesList->setObjectName(QStringLiteral("categoriesList"));
        categoriesList->setGeometry(QRect(10, 90, 151, 451));
        notesList = new QListWidget(centralWidget);
        notesList->setObjectName(QStringLiteral("notesList"));
        notesList->setGeometry(QRect(164, 90, 251, 451));
        noteText = new QTextEdit(centralWidget);
        noteText->setObjectName(QStringLiteral("noteText"));
        noteText->setGeometry(QRect(420, 90, 371, 451));
        noteTitle = new QLineEdit(centralWidget);
        noteTitle->setObjectName(QStringLiteral("noteTitle"));
        noteTitle->setGeometry(QRect(420, 62, 371, 20));
        noteTitle->setReadOnly(true);
        label_2 = new QLabel(centralWidget);
        label_2->setObjectName(QStringLiteral("label_2"));
        label_2->setGeometry(QRect(20, 70, 71, 16));
        label_3 = new QLabel(centralWidget);
        label_3->setObjectName(QStringLiteral("label_3"));
        label_3->setGeometry(QRect(170, 70, 59, 14));
        NotedViewer->setCentralWidget(centralWidget);
        menuBar = new QMenuBar(NotedViewer);
        menuBar->setObjectName(QStringLiteral("menuBar"));
        menuBar->setGeometry(QRect(0, 0, 800, 19));
        NotedViewer->setMenuBar(menuBar);
        mainToolBar = new QToolBar(NotedViewer);
        mainToolBar->setObjectName(QStringLiteral("mainToolBar"));
        NotedViewer->addToolBar(Qt::TopToolBarArea, mainToolBar);
        statusBar = new QStatusBar(NotedViewer);
        statusBar->setObjectName(QStringLiteral("statusBar"));
        NotedViewer->setStatusBar(statusBar);

        retranslateUi(NotedViewer);

        QMetaObject::connectSlotsByName(NotedViewer);
    } // setupUi

    void retranslateUi(QMainWindow *NotedViewer)
    {
        NotedViewer->setWindowTitle(QApplication::translate("NotedViewer", "NotedViewer", Q_NULLPTR));
#ifndef QT_NO_TOOLTIP
        NotedViewer->setToolTip(QApplication::translate("NotedViewer", "Categories", Q_NULLPTR));
#endif // QT_NO_TOOLTIP
        label->setText(QApplication::translate("NotedViewer", "NBAK File:", Q_NULLPTR));
        browseButton->setText(QApplication::translate("NotedViewer", "Select...", Q_NULLPTR));
#ifndef QT_NO_TOOLTIP
        notesList->setToolTip(QApplication::translate("NotedViewer", "Note List", Q_NULLPTR));
#endif // QT_NO_TOOLTIP
        noteText->setPlaceholderText(QApplication::translate("NotedViewer", "Note Text", Q_NULLPTR));
        noteTitle->setPlaceholderText(QApplication::translate("NotedViewer", "Note Title", Q_NULLPTR));
        label_2->setText(QApplication::translate("NotedViewer", "Categories", Q_NULLPTR));
        label_3->setText(QApplication::translate("NotedViewer", "Notes", Q_NULLPTR));
    } // retranslateUi

};

namespace Ui {
    class NotedViewer: public Ui_NotedViewer {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_NOTEDVIEWER_H
