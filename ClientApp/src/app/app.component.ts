import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Building } from './models/building';
import { ReadingService } from './service/reading.service';

import { ReadingModel } from './models/readingModel';
import { ReadModel, ReadModelList } from './models/ReadModel';
import * as CanvasJS from './canvasjs.min';
import { PObject } from './models/pObhect';
import { DataField } from './models/dataField';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ClientApp';
  buildings? : Building[];
  pObjects? : PObject[];
  dataFields? : DataField[]; 
  fromDate? :any; 
  todate? :any;

  readingModel: ReadingModel  = {} as ReadingModel;
  read:ReadModelList = {} as ReadModelList;
  fb: FormGroup;
  
  bsValue = new Date();
  bsRangeValue: Date[];
  maxDate = new Date();

  
  constructor(private builder: FormBuilder, private readingService :ReadingService) {
    
     this.bsRangeValue = [this.bsValue, this.maxDate];
    
    this.fb=this.builder.group({
      fromDate: new FormControl(''),
      toDate: new FormControl(''),
      buildingId: new FormControl(''),
      pObjectId: new FormControl(''),
      dataFieldId: new FormControl(''),
      dateRange :new FormControl('')

    });
    
    }


  ngOnInit(): void {
    this.loadBuilding();
    this.loadDataField();
    this.loadObject();
    
  }

  onDateChange(event:any){
    this.fromDate=event[0];
    this.todate = event[1];
  }
  getReadingByFilter(){
    this.readingModel.buildingId =this.fb.get('buildingId')?.value;
    this.readingModel.dataFieldId =this.fb.get('dataFieldId')?.value;
    this.readingModel.pObjectId = this.fb.get('pObjectId')?.value;
    this.readingModel.fromDate =this.fromDate;
    this.readingModel.toDate =this.todate;

    this.readingService.getReadingByFilter(this.readingModel).subscribe(res=>{
      this.read=res;
      console.log(res,'okkkk');
    });

    var dataPoint = [] as any;
    
    for (var i = 0; i < this.read.values.length; i += 1) {
      dataPoint.push({
        
        x: this.read.timeStamps[i],
        y: this.read.values[i]                
      });
    }

    let chart = new CanvasJS.Chart("chartContainer",{
			theme: "light1",
      title: {
        text: "Time Series Data"
      },
      data: [
        {
          type: "line", 
          dataPoints:dataPoint
        }
      ]
		});
    chart.render();
  
  }


  loadBuilding(){
    this.readingService.getBuildings().subscribe(res=>{
      this.buildings=res;
    },error=>{
      console.log("error list");
    });
  }

  
  loadObject(){
    this.readingService.getPObjects().subscribe(res=>{
      this.pObjects=res;
    },error=>{
      console.log("error list");
    });
  }

  
  loadDataField(){
    this.readingService.getDataFields().subscribe(res=>{
      this.dataFields=res;
    },error=>{
      console.log("error list");
    });
  }
  
  onBuildingChange(id :any){
 this.fb.controls['buildingId'].setValue(id);
  
  }
  onPObjectIdChange(id :any){
    this.fb.controls['pObjectId'].setValue(id);
  }

  onDataFieldIdChange(id :any){
    this.fb.controls['dataFieldId'].setValue(id);
  }
}
