import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Building } from './models/building';
import { ReadingService } from './service/reading.service';
import { Chart, registerables } from 'chart.js';
import { ReadingModel } from './models/readingModel';
import { ReadModel, ReadModelList } from './models/ReadModel';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ClientApp';
  buildings? : Building[];
  pObjects : any;
  dataField : any; 
  fromDate? :any; 
  todate? :any;
  readingModel: ReadingModel  = {} as ReadingModel;

  read:ReadModelList = {} as ReadModelList;
  fb: FormGroup;
  
  bsValue = new Date();
  bsRangeValue: Date[];
  maxDate = new Date();


  chart:any=[];

  
  
  constructor(private builder: FormBuilder, private readingService :ReadingService) {
    Chart.register(...registerables);
     this.bsRangeValue = [this.bsValue, this.maxDate];
    
    this.fb=this.builder.group({
      fromDate: new FormControl(''),
      toDate: new FormControl(''),
      buildingId: new FormControl(''),
      pObjectId: new FormControl(''),
      dataFieldId: new FormControl(''),

    });
    
    }


  ngOnInit(): void {
    this.loadBuilding();
    this.loadDataField();
    this.loadObject();
    
  }


  onDateChange(event:any){
    console.log(event[0],'ok',event[1]);

    this.fromDate=event[0];
    this.todate = event[1];
  }
  getResult(){
    this.readingModel.buildingId =this.fb.get('buildingId')?.value;
    this.readingModel.dataFieldId =this.fb.get('dataFieldId')?.value;
    this.readingModel.pObjectId = this.fb.get('pObjectId')?.value;
    this.readingModel.fromDate =this.fromDate;
    this.readingModel.toDate =this.todate;

    this.readingService.getResult(this.readingModel).subscribe(res=>{
      this.read=res;
      console.log(res,'okkkk');
    });

    this.chart =new Chart('chartLine',{
    
      type: 'line',
      data: {
          labels: [this.read.timeStamps],
          
          datasets: [{
            label: 'Time Series Data',
            data: this.read.values,
            fill: false,
            borderColor: 'rgb(75, 192, 192)',
            tension: 0.1
          }]
      },
    
    })
  
  }


  loadBuilding(){
    this.readingService.getBuildings().subscribe(res=>{
      this.buildings=res;
      console.log('from service',this.buildings);
      
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
      this.dataField=res;
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
