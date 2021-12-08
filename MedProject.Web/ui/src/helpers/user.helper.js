export class UserHelper {
  static IsInRole(user, role) {
    const roles = user.roles;
    return (
      (roles instanceof Array && roles.some((r) => r.toLowerCase() === role)) ||
      (roles instanceof String && roles.toLowerCase() === role)
    );
  }
}
