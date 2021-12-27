import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { BaseModel } from '../models/base-model';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  })
};

export abstract class BaseService<T extends BaseModel> {
  constructor(
    protected http: HttpClient,
    protected baseUrl: string
  ) {
  }

  protected abstract mapToSend(model: T): object;

  public getList(): Observable<T[]> {
    return this.http.get<T[]>(this.baseUrl)
      .pipe(
        catchError(this.handleError)
      );
  }

  public getId(id: number): Observable<T> {
    return this.http.get<T>(`${this.baseUrl}/${id}`)
      .pipe(
        catchError(this.handleError)
      );
  }

  public create(model: T): Observable<T> {
    return this.http.post<T>(this.baseUrl, this.mapToSend(model), httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }

  public update(model: T): Observable<object> {
    return this.http.put(`${this.baseUrl}/${model.id}`, this.mapToSend(model), httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }

  public delete(model: T): Observable<object> {
    return this.http.delete(`${this.baseUrl}/${model.id}`, httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }

  handleError(error: any) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // client-side error
      errorMessage = `Error: ${error.error.message}`;
    } else {
      // server-side error
      errorMessage = `Error Code: ${error.status} \nMessage: ${error.message}`;
    }
    console.error(errorMessage);
    return throwError(errorMessage);

  }
}
