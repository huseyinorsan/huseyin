package com.example.administrator.lightsoutgame;

import android.app.Activity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.LinearLayout;
import android.view.ViewGroup.LayoutParams;
import android.widget.TableLayout;
import android.widget.TableRow;
import android.widget.Toast;
import android.widget.ToggleButton;

public class MainActivity extends Activity {

    TableLayout mainLayout;
    int matrixSize = 5;
    int[][] togleMatrix = new int[matrixSize][matrixSize];

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        mainLayout = (TableLayout) findViewById(R.id.mainLayout);

        for(int i = 0 ; i<matrixSize; i++){
            TableRow tblRow = new TableRow(this);
            TableRow.LayoutParams lnrPrm = new TableRow.LayoutParams(0, LayoutParams.WRAP_CONTENT, 1.0f);
            tblRow.setWeightSum(matrixSize);
            for(int j = 0 ; j<matrixSize; j++){
                togleMatrix[i][j] = 0;
                ToggleButton toggleBtn = new ToggleButton(this);
                toggleBtn.setTag(i + "," + j);
                toggleBtn.setTextOff("0");
                toggleBtn.setTextOn("-");
                toggleBtn.setChecked(false);
                toggleBtn.setOnClickListener(new View.OnClickListener() {
                    @Override
                    public void onClick(View v) {
                        String[] index = ((ToggleButton) v).getTag().toString().split(",");
                        int row = Integer.parseInt(index[0]);
                        int column = Integer.parseInt(index[1]);
                        moveOperation(row, column);
                    }
                });
                tblRow.addView(toggleBtn,lnrPrm);
            }
            mainLayout.addView(tblRow);
        }
    }

    void moveOperation(int i, int j){
        ToggleButton tb;
        try {
            tb = (ToggleButton) mainLayout.findViewWithTag(i + "," + j);
            togleMatrix[i][j] = 1 - togleMatrix[i][j];
        }
        catch ( Exception ex){}

        try {
            tb = (ToggleButton) mainLayout.findViewWithTag((i-1) + "," + j);
            if(tb.isChecked())  tb.setChecked(false);
            else                tb.setChecked(true);
            togleMatrix[i-1][j] = 1 - togleMatrix[i-1][j];
        }
        catch ( Exception ex){}

        try {
            tb = (ToggleButton) mainLayout.findViewWithTag(i + "," + (j-1));
            if(tb.isChecked())  tb.setChecked(false);
            else                tb.setChecked(true);
            togleMatrix[i][j-1] = 1 - togleMatrix[i][j-1];
        }
        catch ( Exception ex){}

        try {
            tb = (ToggleButton) mainLayout.findViewWithTag(i + "," + (j + 1));
            if(tb.isChecked())  tb.setChecked(false);
            else                tb.setChecked(true);
            togleMatrix[i][j+1] = 1 - togleMatrix[i][j+1];
        }
        catch ( Exception ex){}

        try {
            tb = (ToggleButton) mainLayout.findViewWithTag((i+1) + "," + j);
            if(tb.isChecked())  tb.setChecked(false);
            else                tb.setChecked(true);
            togleMatrix[i+1][j] = 1 - togleMatrix[i+1][j];
        }
        catch ( Exception ex){}
        checkGameIsFinished();
    }

    void checkGameIsFinished(){
        for(int i = 0 ; i<matrixSize; i++) {
            for(int j = 0 ; j<matrixSize; j++) {
                if(togleMatrix[i][j] != 1) return;
            }
        }
        Toast.makeText(MainActivity.this, "You Win!!!", Toast.LENGTH_SHORT).show();
    }


    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.menu_main, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        int id = item.getItemId();
        if (id == R.id.action_settings) {
            return true;
        }
        return super.onOptionsItemSelected(item);
    }
}
