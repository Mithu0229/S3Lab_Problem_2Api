import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Building } from '../models/building';
import { DataField } from '../models/dataField';
import { PObject } from '../models/pObhect';
import { ReadingModel } from '../models/readingModel';
import {  ReadModelList } from '../models/ReadModel';

@Injectable({
  providedIn: 'root'
})
export class ReadingService {

  url=environment.apiUrl;
 
  constructor(private http: HttpClient ) {
    
   }


  getBuildings() {
   return this.http.get<Building[]>(this.url + 'Building');
  }

  getPObjects() {
    return this.http.get<PObject[]>(this.url + 'PObject');
   }


   getDataFields() {
    return this.http.get<DataField[]>(this.url + 'DataField');
   }

   getReadingByFilter(model:ReadingModel){
     console.log(model,'ser')
     return this.http.post<ReadModelList>(this.url+'Reading',model);
   }


}
