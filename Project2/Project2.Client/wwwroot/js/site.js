//TODO:
/**
 * REFORMAT: change from class to functions, undo onclick hardcode
 * EXPORT READY: make so can export to array or JSON format
 * BUG FIXES:
 *  extra space at end of canvas
 *  some hardcoding
 * EXTRAish:
 *  Add name implementation
 */

class grid {
    constructor(width, height, ctx, ctxBackground, boxNumberX, boxNumberY) {
        this.width = width;
        this.height = height;
        this.ctxBackground = ctxBackground;
        this.ctx = ctx;
        this.colorArray = new Array(boxNumberX + boxNumberY); //declare/initialize array for holding the current colors
        this.scale;
        this.boxNumberX = boxNumberX;
        this.boxNumberY = boxNumberY;
        this.curColTemp = -1;
        this.curRowTemp = -1;
    }
    
    //create background grid
    //also fills in array of colors for grid
    drawBox() {
        this.scale = Math.min(this.width/this.boxNumberX, this.height/this.boxNumberY);
        for (let i = 0; i < this.boxNumberY; i++) {
            for(let j = 0; j < this.boxNumberX; j++) {
                this.ctxBackground.beginPath();
                this.ctxBackground.rect(j*this.scale, i*this.scale, this.scale, this.scale);
                this.ctxBackground.stroke();
                this.colorArray[this.boxNumberX*i + j] = "#ZZZZZZ";
            }
        }
    }
    
    //find the box that is relative to the cursor placement
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
    
    //draw the box that the cursor is over
    //color is the user color passed to it
    drawBoxAtPosition(curX, curY, color) { //assume already down
        let curPosition = this.findRelativeBox(curX, curY); //find which box we are dealing with
        if(curPosition[0] != -1 && curPosition[1] != -1 && (this.curColTemp != curPosition[0] || this.curRowTemp != curPosition[1])) {
            this.curColTemp = curPosition[0];
            this.curRowTemp = curPosition[1];
            this.ctx.fillStyle = color; //color
            this.ctx.fillRect(curPosition[0]*this.scale, curPosition[1]*this.scale, this.scale, this.scale);
            this.colorArray[curPosition[1]*this.boxNumberX + curPosition[0]] = color;
            this.ctx.stroke();
        }
    }    
}

let c = document.getElementById("myCanvas"); //TODO: change out of getElementById
let cBackground = document.getElementById("backgroundGrid");

//get offset
let offsetY  = c.offsetTop + 100;     //find offset of canvas to top //TODO: FIX OFFSET TO NON HARDCODE
let offsetX  = c.offsetLeft;          //find offset of canvas to left side

let ctx = c.getContext("2d");
let ctxBackground = cBackground.getContext("2d")
let grid1 = new grid(c.width, c.height, ctx, ctxBackground, chosenWidth, chosenHeight);     //TODO: Add in user choice for grid size
let userColor = "#000000";                              //the color user selects

let initialGridColor = new Array (25).fill("#ZZZZZZ");  //temp array to represent blank grid
let userColorCache = [];                                //Holds each grid color pallate. Used for undo purposes. TODO: Implement user choice
userColorCache.push(initialGridColor);                  //Populate grid with initial blank grid

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
    if(mouseX > offsetX && mouseX < offsetX + (grid1.boxNumberX * grid1.scale)
    && mouseY > offsetY && mouseY < offsetY + (grid1.boxNumberY * grid1.scale)) {
        let colorArrayClone = JSON.parse(JSON.stringify(grid1.colorArray));
        userColorCache.push(colorArrayClone);
        console.log("ADDED");
    }

    mouseState = "up";
});

function mouseDown(e) {
    mouseState = "down";
}

function mouseUp(e) {
    mouseState = "up";
}

function undoLast() {
    if(userColorCache.length > 1) { //only undo so if there is something to undo
        userColorCache.pop();
        let mostRecentColors = JSON.parse(JSON.stringify(userColorCache[userColorCache.length -1]));
        for (let i = 0; i < grid1.boxNumberY; i++) {
            for(let j = 0; j < grid1.boxNumberX; j++) {
                curColor = mostRecentColors[grid1.boxNumberX*i + j];
                ctx.beginPath();
                if(curColor == "#ZZZZZZ") {
                    ctx.clearRect(j*grid1.scale, i*grid1.scale, grid1.scale, grid1.scale);
                } else {
                    ctx.fillStyle = curColor;
                    ctx.fillRect(j*grid1.scale, i*grid1.scale, grid1.scale, grid1.scale);
                    ctx.stroke();
                }
            }
        }
    }
}

function changeColor() {
    function isValidHex (hex) {
        //can add additional validation here
        return /^[0-9a-fA-F]+$/.test(hex)
            && (hex.length === 6 || hex.length === 8);
    }
    userInput = document.getElementById("color-text").value;
    if(isValidHex(userInput)) {
        userColor = "#" + userInput;
    }
}

//TODO: Add name functionality:
function exportGrid() {
    let curGrid = {
        gridPallete: grid1.colorArray,
        name: "temp",
        rows: grid1.boxNumberY,
        columns: grid1.boxNumberX
    };
    let json = JSON.stringify(curGrid)
    console.log(json);
}
//TODO: make prettier
let link = document.createElement('a');
link.innerHTML = 'download image';
link.addEventListener('click', function(ev) {
    link.href = c.toDataURL();
    link.download = "pixel-art.png";
}, false);
document.body.appendChild(link);
