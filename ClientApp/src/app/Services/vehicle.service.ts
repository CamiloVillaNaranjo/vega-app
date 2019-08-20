import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { catchError, tap } from "rxjs/operators";
import { Observable } from "rxjs";

import { LogService } from "./log.service";
import { Feature } from "../Models/feature";
import { Make } from "../Models/Makes";

@Injectable({
  providedIn: "root"
})
export class VehicleService {
  constructor(private http: HttpClient, private logService: LogService) {}

  getMakes(): Observable<Make[]> {
    return this.http.get<Make[]>("/api/makes").pipe(
      tap(_ => this.logService.log("Consultando Marcas")),
      catchError(this.logService.handleError<Make[]>("getMakes", []))
    );
  }

  getFeatures(): Observable<Feature[]> {
    return this.http.get<Feature[]>("/api/features").pipe(
      tap(_ => this.logService.log("Consultando Características")),
      catchError(this.logService.handleError<Feature[]>("getFeatures", []))
    );
  }
}
