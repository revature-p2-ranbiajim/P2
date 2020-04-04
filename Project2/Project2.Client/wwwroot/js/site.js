//TODO:
/**
 * REFORMAT: change from class to functions, undo onclick hardcode
 * EXPORT READY: make so can export to array or JSON format
 * BUG FIXES:
 *  extra space at end of canvas
 *  formatting not correctly for click
 *  Undo doesn't undo... it deletes
 */

class grid {
    constructor(width, height, ctx, boxNumberX, boxNumberY) {
        this.width = width;
        this.height = height;
        this.ctx = ctx;
        this.colorArray = new Array(boxNumberX + boxNumberY); //declare/initialize array for holding the current colors
        this.scale;
        this.boxNumberX = boxNumberX;
        this.boxNumberY = boxNumberY;
        this.curColTemp = -1;
        this.curRowTemp = -1;
    }
    
    //make array
    drawBox() {
        this.scale = Math.min(this.width/this.boxNumberX, this.height/this.boxNumberY);
        let i, j;
        for (i = 0; i < this.boxNumberY; i++) {
            for(j = 0; j < this.boxNumberX; j++) {
                this.ctx.beginPath();
                this.ctx.rect(j*this.scale, i*this.scale, this.scale, this.scale);
                this.ctx.stroke();
                this.colorArray.push("#ZZZZZZ"); //-1 = empty
            }
        }
    }
    
    //with mouseState
    findRelativeBox(curX, curY){
        let column, row = -1; 
        for(let x = 0; x < this.boxNumberX; x++){
            if(curX > x*this.scale && curX <= (x+1)*this.scale){
                column = x;
                break;
            }
        }
        
        //find row
        if(column != -1){ //if mouse isn't in canvas, no need to check
            for(let y = 0; y < this.boxNumberY; y++){
                if(curY > y*this.scale && curY <= (y+1)*this.scale){
                    row = y;
                    break;
                }
            }
        }
        return [column, row];
    }
    
    drawBoxAtPosition(curX, curY, color) { //assume already down
        let curPosition = this.findRelativeBox(curX, curY); //find which box we are dealing with
        if(curPosition[0] != -1 && curPosition[1] != -1 && (this.curColTemp != curPosition[0] || this.curRowTemp != curPosition[1])) {
            this.curColTemp = curPosition[0];
            this.curRowTemp = curPosition[1];
            this.ctx.fillStyle = color; //color
            this.ctx.fillRect(curPosition[0]*this.scale, curPosition[1]*this.scale, this.scale, this.scale);
            this.colorArray[curPosition[0] + curPosition[1]] = color;
            this.ctx.stroke();
            //would put undo logic here:
            lastUsedBoxes.push([this.curColTemp, this.curRowTemp]);
            lastUsedColor = color;
        }
    }

    undoDrawBox() {
        let lastUsedColorT = Array.from(undoCache.pop());
        let lastUsedBoxesT = Array.from(undoCache.pop());
        console.log(lastUsedBoxesT.length);
        let tempBoxLocation;
        for(let i = 0; i < lastUsedBoxesT.length; i++) {
            tempBoxLocation = lastUsedBoxesT[i];
            if(lastUsedColor == "#ZZZZZZ") {
                this.ctx.clearRect(tempBoxLocation[0]*this.scale, tempBoxLocation[1]*this.scale, this.scale, this.scale);
            } else {
                this.ctx.fillStyle = "#BBBBBB";
                this.ctx.clearRect(tempBoxLocation[0]*this.scale, tempBoxLocation[1]*this.scale, this.scale, this.scale);
            }
        }
    }
}

/*
//what do I need for an undo?
    - the boxes I just colored
    - the boxes that were there before
    - I am taking the boxes that I just colored, removing them, and replacing them with the old boxes that were there before
    - old boxes had location and color
*/


let c = document.getElementById("myCanvas"); //TODO: change out of getElementById

//get offset
let bodyRect = document.body.getBoundingClientRect();   //get position of body element
let elemRect = c.getBoundingClientRect();               //get position of canvas element
let offsetY  = elemRect.top - bodyRect.top;             //find offset of canvas to top
let offsetX  = elemRect.left - bodyRect.left;           //find offset of canvas to left side

let ctx = c.getContext("2d");
let grid1 = new grid(c.width, c.height, ctx, 24, 12); //TODO: should adjust dynamically to canvas
let userColor = "#000000";
let undoCache = [];
let lastUsedBoxes = [];
let lastUsedColor = "#ZZZZZZ";

grid1.drawBox();

document.onmousemove = mouseMove;
document.onmousedown = mouseDown;
let mouseState = "up";

//get mouseX, mouseY
let mouseX = 0;
let mouseY = 0;
function mouseMove(e) {
    mouseX = e.screenX;
    mouseY = e.screenY;
    if(mouseState == "down") {
        grid1.drawBoxAtPosition(mouseX - offsetX, mouseY - offsetY, userColor);
    }
    
    if(mouseState == "up") {
        //mouse is not being clicked
    }
}

document.addEventListener("click", function(e) {
    mouseState = "up";
    grid1.drawBoxAtPosition(mouseX - offsetX, mouseY - offsetY, userColor);
    //push the most recent unit batch
    undoCache.push(Array.from(lastUsedBoxes));
    lastUsedBoxes.splice(0, lastUsedBoxes.length);
    undoCache.push(lastUsedColor);
});

function mouseDown(e) {
    mouseState = "down";
}

function mouseUp(e) {
    mouseState = "up";
}

function undoLast() {
    grid1.undoDrawBox();
}


//add 